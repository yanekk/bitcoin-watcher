using BitCoinWatcher.BitBayApi.Enums;

namespace BitCoinWatcher.BitBayApi
{
    public interface IBitBayClient
    {
        decimal GetLatestExchangeRate(Currency fromCurrency, Currency toCurrency);
        decimal GetViableExchangeRate(decimal offerExchangeRate, decimal feeRate);
        string GetCurrencyName(Currency currency);
        decimal GetProfit(decimal amountSpent, decimal offerExchangeRate, decimal currentExchangeRate, decimal feeRate);
    }
}
