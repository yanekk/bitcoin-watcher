using BitCoinWatcher.BitBayApi.Enums;

namespace BitCoinWatcher.BitBayApi.CurrencyMetadata
{
    internal class EthereumMetadata : ICurrencyMetadata
    {
        public Currency Currency => Currency.Ethereum;
        public string Name => "Ethereum";
        public string Abbreviation => "eth";
    }
}
