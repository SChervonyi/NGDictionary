using NGDictionary.Database.Interfaces.Repositories;
using System;

namespace NGDictionary.Database.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IDictionaryRepository DictionaryRepository { get; }

        IUserRepository UserRepository { get; }

        IWordRepository WordRepository { get; }

        void Save();
    }
}
