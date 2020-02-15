using NGDictionary.Database.Entity;
using System;
using System.Collections.Generic;

namespace NGDictionary.Database.Interfaces.Repositories
{
    public interface IDictionaryRepository
    {
        void AddOrUpdateDictionary(Dictionary dictionary);

        IList<DictionaryMeta> GetAllUserDictionariesMeta(int userId);

        Dictionary GetDictionary(Guid uid);

        void DeleteDictionary(string dictionaryName);
    }
}
