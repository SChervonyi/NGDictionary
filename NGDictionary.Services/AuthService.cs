using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using NGDictionary.Database.Interfaces.Repositories;
using NGDictionary.Dto;
using NGDictionary.Services.Interfaces;
using NGDictionary.Services.Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace NGDictionary.Services
{
    public class AuthService : IAuthService
    {
        private IUserRepository userRepository;
        private IPasswordHasher passwordHasher;

        public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
        }

        public void AddUser(User user)
        {
            user.Password = passwordHasher.Hash(user.Password);
            userRepository.AddUser(user);
        }

        public void DeleteUser(int userId)
        {
            userRepository.DeleteUser(userId);
        }

        public User GetUserByLogin(string login)
        {
            return userRepository.GetUserByLogin(login);
        }

        public void UpdateUser(User user)
        {
            userRepository.UpdateUser(user);
        }

        private bool CheckPassword(string user, string password)
        {
            // TODO: Implement
            return true;
        }
    }
}
