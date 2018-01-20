using BitCoinWatcher.BitBayApi.Enums;

namespace BitCoinWatcher.BitBayApi.CurrencyMetadata
{
    internal class GameMetadata : ICurrencyMetadata
    {
        public Currency Currency => Currency.Game;
        public string Name => "GameCredits";
        public string Abbreviation => "game";
    }
}
