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
        private bool disposed = false;

        private IUnitOfWork unitOfWork;
        private IPasswordHasher passwordHasher;

        public AuthService(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            this.unitOfWork = unitOfWork;
            this.passwordHasher = passwordHasher;
        }

        public void AddUser(User user)
        {
            user.Password = passwordHasher.Hash(user.Password);
            unitOfWork.UserRepository.AddUser(user);
            unitOfWork.Save();
        }

        public void UpdatePassword(string login, string newPassword)
        {
            var user = unitOfWork.UserRepository.GetUserByLogin(login);
            if (user is null) throw new ApplicationException("User not found.");

            user.Password = passwordHasher.Hash(newPassword);
            unitOfWork.UserRepository.UpdateUser(user);
            unitOfWork.Save();
        }

        public void DeleteUser(int userId)
        {
            unitOfWork.UserRepository.DeleteUser(userId);
            unitOfWork.Save();
        }

        public User Login(string login, string password)
        {
            // TODO: Handle if needsUpgrade is true;
            var user = unitOfWork.UserRepository.GetUserByLogin(login);
            if (user is null) throw new AuthenticationException("Login/Password combination is not valid.");

            var (verified, needsUpgrade) = passwordHasher.Check(user.Password, password);

            if(!verified) throw new AuthenticationException("Login/Password combination is not valid.");

            return user;
        }

        public void UpdateUser(User user)
        {
            unitOfWork.UserRepository.UpdateUser(user);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    unitOfWork.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
