using System;
using System.Data.Entity;
using BitCoinWatcher.DataAccess.Entities;

namespace BitCoinWatcher.DataAccess
{
    interface IBitCoinWatcherDbContext : IDisposable
    {
        DbSet<CoinItem> CoinItems { get; set; }

        int SaveChanges();
    }
}
