using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGDictionary.Dto
{
    public class Word
    {
        public Guid Id { get; set; }

        public string Text { get; set; } = null!;

        public string Translation { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string? AudioUrl { get; set; }

        public string? Details { get; set; }

        [JsonIgnore]
        public Guid DictionaryId { get; set; }
    }
}
