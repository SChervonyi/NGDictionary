using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGDictionary.Dto
{
    public class User
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;

        public IList<UserDictionary>? Dictionaries { get; set; }
    }
}
