using System.Collections.Generic;
using System.Linq;
using BitCoinWatcher.DataAccess.Entities;
using BitCoinWatcher.DataAccess.Repositories.Base;

namespace BitCoinWatcher.DataAccess.Repositories
{
    internal class TransactionRepository : Repository, ITransactionRepository
    {
        public TransactionRepository(IBitCoinWatcherDbContext dbContext) : base(dbContext)
        {
        }

        public IList<Transaction> GetAll()
        {
            return DbContext.Transactions
                .OrderBy(item => item.AddedAt)
                .ToList();
        }

        public void Add(Transaction transaction)
        {
            DbContext.Transactions.Add(transaction);
            DbContext.SaveChanges();
        }

        public Transaction Get(int id)
        {
            return DbContext.Transactions.Find(id);
        }

        public void Remove(Transaction transaction)
        {
            DbContext.Transactions.Remove(transaction);
            DbContext.SaveChanges();
        }
    }
}
