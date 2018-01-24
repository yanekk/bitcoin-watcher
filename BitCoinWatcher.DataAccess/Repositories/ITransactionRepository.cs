using System.Collections.Generic;
using BitCoinWatcher.DataAccess.Entities;
using BitCoinWatcher.DataAccess.Repositories.Base;

namespace BitCoinWatcher.DataAccess.Repositories
{
    public interface ITransactionRepository : IRepository
    {
        IList<Transaction> GetAll();
        void Add(Transaction transaction);
        Transaction Get(int id);
        void Remove(Transaction transaction);
    }
}
