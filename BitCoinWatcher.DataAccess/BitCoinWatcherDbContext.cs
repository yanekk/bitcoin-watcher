using System.Data.Entity;
using BitCoinWatcher.DataAccess.Entities;

namespace BitCoinWatcher.DataAccess
{
    public class BitCoinWatcherDbContext : DbContext, IBitCoinWatcherDbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
    }
}
