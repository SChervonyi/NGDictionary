using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGDictionary.Dto
{
    public class UserDto
    {
        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public IList<DictionaryDto>? Dictionaries { get; set; }
    }
}
