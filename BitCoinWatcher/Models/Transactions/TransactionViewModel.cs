using System;

namespace BitCoinWatcher.Models.Transactions
{
    [Serializable]
    public class TransactionViewModel
    {
        public int Id;
        public decimal AmountSpent;
        public decimal OfferExchangeRate;
        public decimal AmountBought;
        public string Currency;
        public decimal CurrentExchangeRate;
        public decimal ViableExchangeRate;
        public decimal Profit;
    }
}