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

        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
