using System;

namespace BitCoinWatcher.DataAccess.Repositories.Base
{
    internal class Repository
    {
        protected readonly IBitCoinWatcherDbContext DbContext;
        private bool _disposed;

        public Repository(IBitCoinWatcherDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
