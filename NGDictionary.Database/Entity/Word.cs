using System;
using System.Collections.Generic;
using System.Text;

namespace NGDictionary.Database.Entity
{
    public class Word
    {
        public Guid Id { get; set; }

        public string Text { get; set; } = null!;

        public string Translation { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string? AudioUrl { get; set; }

        public string? Details { get; set; }

        public Dictionary Dictionary { get; set; } = null!;

        public Guid DictionaryId { get; set; }
    }
}
