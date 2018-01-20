using Newtonsoft.Json;

namespace BitCoinWatcher.BitBayApi.Models
{
    internal class ResponseModel
    {
        [JsonProperty("code")]
        public int Code;

        [JsonProperty("request")]
        public string Request;

        [JsonProperty("data")]
        public TickerModel Data;

        [JsonProperty("status")]
        public string Status;
    }
}
