namespace BitCoinWatcher.BitBayApi.Services
{
    internal class CalculationService : ICalculationService
    {
        public decimal CalculateViableExchangeRate(decimal offerExchangeRate, decimal feeRate)
        {
            return Rounded(offerExchangeRate/(1 - feeRate) + offerExchangeRate/(1 - feeRate)*feeRate);
        }

        public decimal CalculateProfit(decimal amountSpent, decimal offerExchangeRate, decimal currentExchangeRate, decimal feeRate)
        {
            var amountBought = amountSpent/offerExchangeRate;
            var income = (amountBought - amountBought * feeRate)*currentExchangeRate;
            return Rounded(income - income * feeRate - amountSpent);
        }

        private decimal Rounded(decimal number)
        {
            return decimal.Round(number, 2);
        }
    }
}
