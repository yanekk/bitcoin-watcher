namespace BitCoinWatcher.BitBayApi.Services
{
    internal interface IHttpRequestService : ICoreService
    {
        string Get(string currencyFrom, string currencyTo, string requestType);
    }
}
