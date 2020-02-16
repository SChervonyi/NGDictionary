using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGDictionary.Dto
{
    public class WordDto
    {
        public string Text { get; set; } = null!;

        public string Translation { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string? AudioUrl { get; set; }

        public string? Details { get; set; }

        public DictionaryDto Dictionary { get; set; } = null!;
    }
}
