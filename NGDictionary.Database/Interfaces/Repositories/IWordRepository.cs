using NGDictionary.Dto;
using System;

namespace NGDictionary.Database.Interfaces.Repositories
{
    interface IWordRepository : IDisposable
    {
        void SaveOrUpdateWord(Word word, Guid dictionaryUid);

        void DeleteWord(Guid uid, Guid dictionaryUid);
    }
}
