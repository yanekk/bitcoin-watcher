using BitCoinWatcher.BitBayApi.Enums;

namespace BitCoinWatcher.BitBayApi.CurrencyMetadata
{
    public interface ICurrencyMetadata
    {
        Currency Currency { get; }
        string Name { get; }
        string Abbreviation { get; }
    }
}
