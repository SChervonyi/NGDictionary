using NGDictionary.Database.Interfaces;
using NGDictionary.Dto;
using NGDictionary.Services.Interfaces;
using NGDictionary.Services.Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Security.Authentication;

namespace NGDictionary.Services
{
    public class AuthService : IAuthService, IDisposable
    {
        private bool _disposed = false;

        private IUnitOfWork _unitOfWork;
        private IPasswordHasher _passwordHasher;

        public AuthService(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        public void AddUser(User user)
        {
            user.Password = _passwordHasher.Hash(user.Password);
            _unitOfWork.UserRepository.AddUser(user);
            _unitOfWork.Save();
        }

        public void UpdatePassword(string username, string newPassword)
        {
            var user = _unitOfWork.UserRepository.GetUserByUsername(username);
            if (user is null) throw new ApplicationException("User not found.");

            user.Password = _passwordHasher.Hash(newPassword);
            _unitOfWork.UserRepository.UpdateUser(user);
            _unitOfWork.Save();
        }

        public void DeleteUser(int userId)
        {
            _unitOfWork.UserRepository.DeleteUser(userId);
            _unitOfWork.Save();
        }

        public User Login(string username, string password)
        {
            // TODO: Handle if needsUpgrade is true;
            var user = _unitOfWork.UserRepository.GetUserByUsername(username);
            if (user is null) throw new AuthenticationException("Login/Password combination is not valid.");

            var (verified, needsUpgrade) = _passwordHasher.Check(user.Password, password);

            if(!verified) throw new AuthenticationException("Login/Password combination is not valid.");

            return user;
        }

        public void UpdateUser(User user)
        {
            _unitOfWork.UserRepository.UpdateUser(user);
            _unitOfWork.Save();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _unitOfWork.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
