using RestSharp;

namespace BitCoinWatcher.BitBayApi.Services
{
    internal class HttpRequestService : IHttpRequestService
    {
        internal static string PublicApiAddress = "http://bitcoinstat.org/api_v3";
        internal static string ExchangeName = "Bitbay";

        public string Get(string currencyFrom, string currencyTo, string requestType)
        {
            var client = new RestClient(PublicApiAddress);
            var request = new RestRequest(requestType+"/");
            request.Parameters.Add(new Parameter
            {
                Name = "coin",
                Value = currencyTo,
                Type = ParameterType.GetOrPost
            });
            request.Parameters.Add(new Parameter
            {
                Name = "currency",
                Value = currencyFrom,
                Type = ParameterType.GetOrPost
            });
            request.Parameters.Add(new Parameter
            {
                Name = "exchange",
                Value = ExchangeName,
                Type = ParameterType.GetOrPost
            });
            var response = client.Get(request);
            return response.Content;
        }
    }
}
