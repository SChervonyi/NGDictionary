﻿using NGDictionary.Database.Interfaces.Repositories;
using NGDictionary.Database.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGDictionary.Database.Repositories
{
    public class WordRepository : IWordRepository
    {
        public WordRepository(EFDbContext context)
        {
        }

        public void DeleteWord(Guid uid, Guid dictionaryUid)
        {
            throw new NotImplementedException();
        }

        public void SaveOrUpdateWord(Word word, Guid dictionaryUid)
        {
            throw new NotImplementedException();
        }
    }
}
