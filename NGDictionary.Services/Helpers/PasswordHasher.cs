using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Options;
using NGDictionary.Services.Interfaces.Helpers;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace NGDictionary.Services.Helpers
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 16; // 128 bit 
        private const int KeySize = 32; // 256 bit

        public PasswordHasher(IOptions<HashingOptions> options)
        {
            Options = options.Value;
        }

        private HashingOptions Options { get; }

        public (bool Verified, bool NeedsUpgrade) Check(string hash, string password)
        {
            var parts = hash.Split('.', 3);

            if (parts.Length != 3)
            {
                throw new FormatException("Unexpected hash format.");
            }

            var iterations = Convert.ToInt32(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var savedKey = Convert.FromBase64String(parts[2]);

            var needsUpgrade = iterations != Options.Iterations;

            var keyToCheck = KeyHash(password, iterations, salt);

            var verifyed = keyToCheck.SequenceEqual(savedKey);

            return (verifyed, needsUpgrade);
        }

        public string Hash(string password)
        {
            var saltBytes = GenerateRandomSalt();
            var keyBytes = KeyHash(password, Options.Iterations, saltBytes);
            var key = Convert.ToBase64String(keyBytes);
            var salt = Convert.ToBase64String(saltBytes);
            return $"{Options.Iterations}.{salt}.{key}";
        }

        private byte[] KeyHash(string password, int iterations, byte[] saltBytes)
        {
            return KeyDerivation.Pbkdf2(
                    password: password,
                    salt: saltBytes,
                    prf: KeyDerivationPrf.HMACSHA512,
                    iterationCount: iterations,
                    numBytesRequested: KeySize);
        }

        private byte[] GenerateRandomSalt()
        {
            byte[] randomBytes = new byte[SaltSize];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(randomBytes);
                return randomBytes;
            }
        }
    }
}
