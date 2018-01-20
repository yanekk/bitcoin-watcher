using BitCoinWatcher.BitBayApi.Enums;

namespace BitCoinWatcher.BitBayApi.CurrencyMetadata
{
    internal class PlnMetadata : ICurrencyMetadata
    {
        public Currency Currency => Currency.Pln;
        public string Name => "Zloty";
        public string Abbreviation => "pln";
    }
}
