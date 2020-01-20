using Microsoft.EntityFrameworkCore;
using System;

namespace NGDictionary.Database.Repositories
{
    public abstract class BaseRepository<T> : IDisposable where T: DbContext
    {
        private bool disposed = false;
        protected T context;

        public BaseRepository(T context)
        {
            this.context = context;
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
