using BitCoinWatcher.BitBayApi.Enums;

namespace BitCoinWatcher.BitBayApi.Services
{
    internal interface ICurrencyMetadataService : ICoreService
    {
        string GetCurrencyAbbreviation(Currency currency);
        string GetCurrencyName(Currency currency);
    }
}
