using System.Collections.Generic;
using BitCoinWatcher.DataAccess.Entities;
using BitCoinWatcher.DataAccess.Repositories.Base;

namespace BitCoinWatcher.DataAccess.Repositories
{
    public interface ICoinItemRepository : IRepository
    {
        IList<CoinItem> GetAll();
        void Add(CoinItem coinItem);
        CoinItem Get(int id);
        void Remove(CoinItem coinItem);
    }
}
