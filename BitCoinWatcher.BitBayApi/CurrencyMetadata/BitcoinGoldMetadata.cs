using BitCoinWatcher.BitBayApi.Enums;

namespace BitCoinWatcher.BitBayApi.CurrencyMetadata
{
    internal class BitcoinGoldMetadata : ICurrencyMetadata
    {
        public Currency Currency => Currency.BitcoinGold;
        public string Name => "Bitcoin Gold";
        public string Abbreviation => "btg";
    }
}
