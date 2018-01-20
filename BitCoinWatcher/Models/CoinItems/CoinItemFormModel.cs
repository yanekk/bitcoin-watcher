using BitCoinWatcher.BitBayApi.Enums;
using FluentValidation.Attributes;

namespace BitCoinWatcher.Models.CoinItems
{
    [Validator(typeof(CoinItemFormModelValidator))]
    public class CoinItemFormModel
    {
        public decimal AmountSpent { get; set; }
        public decimal OfferExchangeRate { get; set; }
        public Currency Currency { get; set; }
    }
}