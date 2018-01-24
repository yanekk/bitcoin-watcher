using BitCoinWatcher.BitBayApi.Enums;
using FluentValidation.Attributes;

namespace BitCoinWatcher.Models.Transactions
{
    [Validator(typeof(TransactionFormModelValidator))]
    public class TransactionFormModel
    {
        public decimal AmountSpent { get; set; }
        public decimal OfferExchangeRate { get; set; }
        public Currency Currency { get; set; }
    }
}