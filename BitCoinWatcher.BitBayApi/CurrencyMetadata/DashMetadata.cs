using BitCoinWatcher.BitBayApi.Enums;

namespace BitCoinWatcher.BitBayApi.CurrencyMetadata
{
    internal class DashMetadata : ICurrencyMetadata
    {
        public Currency Currency => Currency.Dash;
        public string Name => "Dash";
        public string Abbreviation => "dsh";
    }
}
