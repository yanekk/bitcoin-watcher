using System;
using System.Data.Entity;
using BitCoinWatcher.DataAccess.Entities;

namespace BitCoinWatcher.DataAccess
{
    interface IBitCoinWatcherDbContext : IDisposable
    {
        DbSet<Transaction> Transactions { get; set; }

        int SaveChanges();
    }
}
