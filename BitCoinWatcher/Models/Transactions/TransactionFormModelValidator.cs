using BitCoinWatcher.BitBayApi.Enums;
using FluentValidation;

namespace BitCoinWatcher.Models.Transactions
{
    public class TransactionFormModelValidator : AbstractValidator<TransactionFormModel>
    {
        public TransactionFormModelValidator()
        {
            RuleFor(m => m.Currency)
                .NotEqual(Currency.Pln);
            RuleFor(m => m.AmountSpent)
                .GreaterThan(0);
            RuleFor(m => m.OfferExchangeRate)
                .GreaterThan(0);
        }
    }
}