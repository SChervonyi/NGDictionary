using NGDictionary.Database.Interfaces.Repositories;
using NGDictionary.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGDictionary.Database.Repositories
{
    public class WordRepository : BaseRepository<EFDbContext>, IWordRepository
    {
        public WordRepository(EFDbContext context)
            : base(context)
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
