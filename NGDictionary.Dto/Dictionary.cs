﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NGDictionary.Dto
{
    public class Dictionary
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public bool IsFavorite { get; set; }

        public IList<Word> Words { get; set; }
    }
}
