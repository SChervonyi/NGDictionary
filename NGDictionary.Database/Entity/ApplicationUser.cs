using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGDictionary.Database.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public IList<UserDictionary>? UserDictionaries { get; set; }
    }
}
