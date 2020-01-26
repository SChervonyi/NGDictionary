using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using NGDictionary.Database.Interfaces.Repositories;
using NGDictionary.Dto;
using NGDictionary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace NGDictionary.Services
{
    public class AuthService : IAuthService
    {
        private IUserRepository userRepository;

        public AuthService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void AddUser(User user)
        {
            user.Password = GeneratePasswordHash(user.Password);
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
            /* Fetch the stored value */
            string savedPasswordHash = userRepository.GetUserByLogin(user).Password;
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                    throw new UnauthorizedAccessException();
            }
            return true;
        }

        private string GeneratePasswordHash(string password)
        {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
           return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }
    }
}
