using NGDictionary.Database.Interfaces;
using NGDictionary.Database.Interfaces.Repositories;
using NGDictionary.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGDictionary.Database
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private bool disposed = false;
        protected EFDbContext context;

        public UnitOfWork(EFDbContext context)
        {
            this.context = context;
            DictionaryRepository = new DictionaryRepository(context);
            UserRepository = new UserRepository(context);
            WordRepository = new WordRepository(context);
        }

        public IDictionaryRepository DictionaryRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public IWordRepository WordRepository { get; private set; }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
