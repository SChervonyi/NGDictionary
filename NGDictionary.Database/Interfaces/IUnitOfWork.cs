using NGDictionary.Database.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace NGDictionary.Database.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IDictionaryRepository DictionaryRepository { get; }

        IUserRepository UserRepository { get; }

        IWordRepository WordRepository { get; }

        Task SaveAsync();
    }
}
