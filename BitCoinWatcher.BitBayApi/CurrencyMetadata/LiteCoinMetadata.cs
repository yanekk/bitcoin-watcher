using BitCoinWatcher.BitBayApi.Enums;

namespace BitCoinWatcher.BitBayApi.CurrencyMetadata
{
    internal class LiteCoinMetadata : ICurrencyMetadata
    {
        public Currency Currency => Currency.LiteCoin;
        public string Name => "LiteCoin";
        public string Abbreviation => "ltc";
    }
}
