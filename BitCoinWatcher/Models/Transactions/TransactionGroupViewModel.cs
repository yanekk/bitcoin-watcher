using System;
using System.Collections.Generic;

namespace BitCoinWatcher.Models.Transactions
{
    [Serializable]
    public class TransactionGroupViewModel
    {
        public string Currency;
        public decimal CurrentExchangeRate;
        public List<TransactionViewModel> Transactions = new List<TransactionViewModel>();
    }
}