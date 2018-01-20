using System.Collections.Generic;
using System.Linq;
using BitCoinWatcher.DataAccess.Entities;
using BitCoinWatcher.DataAccess.Repositories.Base;

namespace BitCoinWatcher.DataAccess.Repositories
{
    internal class CoinItemRepository : Repository, ICoinItemRepository
    {
        public CoinItemRepository(IBitCoinWatcherDbContext dbContext) : base(dbContext)
        {
        }

        public IList<CoinItem> GetAll()
        {
            return DbContext.CoinItems
                .OrderBy(item => item.AddedAt)
                .ToList();
        }

        public void Add(CoinItem coinItem)
        {
            DbContext.CoinItems.Add(coinItem);
            DbContext.SaveChanges();
        }

        public CoinItem Get(int id)
        {
            return DbContext.CoinItems.Find(id);
        }

        public void Remove(CoinItem coinItem)
        {
            DbContext.CoinItems.Remove(coinItem);
            DbContext.SaveChanges();
        }
    }
}
