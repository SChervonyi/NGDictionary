﻿using NGDictionary.Database.Interfaces.Repositories;
using NGDictionary.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGDictionary.Database.Repositories
{
    class DictionaryRepository : BaseRepository<EFDbContext>, IDictionaryRepository
    {
        public DictionaryRepository(EFDbContext context)
            : base(context)
        {
        }

        public void AddOrUpdateDictionary(Dictionary dictionary)
        {
            throw new NotImplementedException();
        }

        public void DeleteDictionary(string dictionaryName)
        {
            throw new NotImplementedException();
        }

        public IList<DictionaryMeta> GetAllUserDictionariesMeta(int userId)
        {
            throw new NotImplementedException();
        }

        public Dictionary GetDictionary(Guid uid)
        {
            throw new NotImplementedException();
        }
    }
}
