using NGDictionary.Database.Entity;
using System;

namespace NGDictionary.Database.Interfaces.Repositories
{
    public interface IWordRepository
    {
        void SaveOrUpdateWord(Word word, Guid dictionaryUid);

        void DeleteWord(Guid uid, Guid dictionaryUid);
    }
}
