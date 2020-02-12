using System;
using System.Collections.Generic;
using System.Text;

namespace NGDictionary.Dto
{
    public class UserDictionary
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public Guid DictionaryId { get; set; }
        public Dictionary Dictionary { get; set; } = null!;
    }
}
