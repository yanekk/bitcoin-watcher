using BitCoinWatcher.BitBayApi.Enums;
using FluentValidation;

namespace BitCoinWatcher.Models.CoinItems
{
    public class CoinItemFormModelValidator : AbstractValidator<CoinItemFormModel>
    {
        public CoinItemFormModelValidator()
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