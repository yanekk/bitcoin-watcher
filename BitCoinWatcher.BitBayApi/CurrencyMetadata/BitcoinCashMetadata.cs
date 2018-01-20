using BitCoinWatcher.BitBayApi.Enums;

namespace BitCoinWatcher.BitBayApi.CurrencyMetadata
{
    internal class BitcoinCashMetadata : ICurrencyMetadata
    {
        public Currency Currency => Currency.BitcoinCash;
        public string Name => "Bitcoin Cash";
        public string Abbreviation => "bcc";
    }
}
