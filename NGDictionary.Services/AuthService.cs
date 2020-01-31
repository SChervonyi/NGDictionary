using NGDictionary.Database.Interfaces.Repositories;
using NGDictionary.Dto;
using NGDictionary.Services.Interfaces;
using NGDictionary.Services.Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Security.Authentication;

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

        public void UpdatePassword(string login, string newPassword)
        {
            var user = userRepository.GetUserByLogin(login);
            user.Password = passwordHasher.Hash(newPassword);
            userRepository.UpdateUser(user);
        }

        public void DeleteUser(int userId)
        {
            userRepository.DeleteUser(userId);
        }

        public User Login(string login, string password)
        {
            // TODO: Handle if needsUpgrade is true;
            var user = userRepository.GetUserByLogin(login);
            if (user is null) throw new AuthenticationException("Login/Password combination is not valid.");

            var (verified, needsUpgrade) = passwordHasher.Check(user.Password, password);

            if(!verified) throw new AuthenticationException("Login/Password combination is not valid.");

            return user;
        }

        public void UpdateUser(User user)
        {
            userRepository.UpdateUser(user);
        }
    }
}
