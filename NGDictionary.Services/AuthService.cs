using NGDictionary.Database.Interfaces;
using NGDictionary.Dto;
using NGDictionary.Services.Interfaces;
using NGDictionary.Services.Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Threading.Tasks;

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

        public async Task AddUserAsync(User user)
        {
            user.Password = _passwordHasher.Hash(user.Password);
            await _unitOfWork.UserRepository.AddUserAsync(user);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdatePasswordAsync(string username, string newPassword)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(username);
            if (user is null) throw new ApplicationException("User not found.");

            user.Password = _passwordHasher.Hash(newPassword);
            _unitOfWork.UserRepository.UpdateUser(user);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _unitOfWork.UserRepository.DeleteUserAsync(userId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            // TODO: Handle if needsUpgrade is true;
            var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(username);
            if (user is null) throw new AuthenticationException("Login/Password combination is not valid.");

            var (verified, needsUpgrade) = _passwordHasher.Check(user.Password, password);

            if(!verified) throw new AuthenticationException("Login/Password combination is not valid.");

            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            _unitOfWork.UserRepository.UpdateUser(user);
            await _unitOfWork.SaveAsync();
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
