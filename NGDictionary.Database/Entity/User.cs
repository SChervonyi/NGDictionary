﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NGDictionary.Database.Entity
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;

        public IList<UserDictionary>? UserDictionaries { get; set; }
    }
}
