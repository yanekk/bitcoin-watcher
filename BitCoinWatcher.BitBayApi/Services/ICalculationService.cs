namespace BitCoinWatcher.BitBayApi.Services
{
    internal interface ICalculationService : ICoreService
    {
        decimal CalculateViableExchangeRate(decimal offerExchangeRate, decimal feeRate);
        decimal CalculateProfit(decimal amountSpent, decimal offerExchangeRate, decimal currentExchangeRate, decimal feeRate);
    }
}
