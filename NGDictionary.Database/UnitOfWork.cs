using NGDictionary.Database.Interfaces;
using NGDictionary.Database.Interfaces.Repositories;
using NGDictionary.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NGDictionary.Database
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private bool _disposed = false;
        protected EFDbContext _context;

        public UnitOfWork(EFDbContext context)
        {
            _context = context;
            DictionaryRepository = new DictionaryRepository(context);
            UserRepository = new UserRepository(context);
            WordRepository = new WordRepository(context);
        }

        public IDictionaryRepository DictionaryRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public IWordRepository WordRepository { get; private set; }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
