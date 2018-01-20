using System.Collections.Generic;
using System.Linq;
using BitCoinWatcher.BitBayApi.CurrencyMetadata;
using BitCoinWatcher.BitBayApi.Enums;

namespace BitCoinWatcher.BitBayApi.Services
{
    internal class CurrencyMetadataService : ICurrencyMetadataService
    {
        private readonly Dictionary<Currency, ICurrencyMetadata> _currencyMetadatas;

        public CurrencyMetadataService(IList<ICurrencyMetadata> currencyMetadatas)
        {
            _currencyMetadatas = currencyMetadatas.ToDictionary(m => m.Currency, m => m);
        }

        public string GetCurrencyAbbreviation(Currency currency)
        {
            return GetCurrencyMetadata(currency).Abbreviation;
        }

        public string GetCurrencyName(Currency currency)
        {
            return GetCurrencyMetadata(currency).Name;
        }

        private ICurrencyMetadata GetCurrencyMetadata(Currency currency)
        {
            return _currencyMetadatas[currency];
        }
    }
}
