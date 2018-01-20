using BitCoinWatcher.BitBayApi.Enums;

namespace BitCoinWatcher.BitBayApi.CurrencyMetadata
{
    internal class BitcoinMetadata : ICurrencyMetadata
    {
        public Currency Currency => Currency.Bitcoin;
        public string Name => "Bitcoin";
        public string Abbreviation => "btc";
    }
}
