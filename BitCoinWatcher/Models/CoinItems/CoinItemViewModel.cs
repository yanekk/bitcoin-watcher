using System;

namespace BitCoinWatcher.Models.CoinItems
{
    [Serializable]
    public class CoinItemViewModel
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