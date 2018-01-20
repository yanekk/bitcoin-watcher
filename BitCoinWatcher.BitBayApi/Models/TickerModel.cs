using Newtonsoft.Json;

namespace BitCoinWatcher.BitBayApi.Models
{
    internal class TickerModel
    {
        [JsonProperty("last")]
        public decimal Last { get; set; }
    }
}
