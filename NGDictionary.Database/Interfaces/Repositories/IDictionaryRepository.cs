using NGDictionary.Dto;
using System;
using System.Collections.Generic;

namespace NGDictionary.Database.Interfaces.Repositories
{
    interface IDictionaryRepository : IDisposable
    {
        void AddOrUpdateDictionary(Dictionary dictionary);

        IList<DictionaryMeta> GetAllUserDictionariesMeta(int userId);

        Dictionary GetDictionary(Guid uid);

        void DeleteDictionary(string dictionaryName);
    }
}
