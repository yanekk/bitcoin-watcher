using BitCoinWatcher.BitBayApi.Enums;

namespace BitCoinWatcher.BitBayApi.CurrencyMetadata
{
    internal class LiskMetadata : ICurrencyMetadata
    {
        public Currency Currency => Currency.Lisk;
        public string Name => "Lisk";
        public string Abbreviation => "lsk";
    }
}
