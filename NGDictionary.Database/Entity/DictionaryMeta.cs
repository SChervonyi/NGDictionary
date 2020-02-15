using System;
using System.Collections.Generic;
using System.Text;

namespace NGDictionary.Database.Entity
{
    public class DictionaryMeta
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public bool IsFavorite { get; set; }

        public string? ImageUrl { get; set; }
    }
}
