using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGDictionary.Dto
{
    public class DictionaryDto
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsFavorite { get; set; }

        public IList<WordDto>? Words { get; set; }
    }
}
