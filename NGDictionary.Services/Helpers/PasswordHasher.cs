using NGDictionary.Services.Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGDictionary.Services.Helpers
{
    public class PasswordHasher : IPasswordHasher
    {
        public (bool Verified, bool NeedsUpgrade) Check(string hash, string password)
        {
            throw new NotImplementedException();
        }

        public string Hash(string password)
        {
            throw new NotImplementedException();
        }
    }
}
