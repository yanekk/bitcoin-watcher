using System.Collections.Generic;
using BitCoinWatcher.BitBayApi.Enums;
using BitCoinWatcher.BitBayApi.Models;
using BitCoinWatcher.BitBayApi.Services;
using Newtonsoft.Json;

namespace BitCoinWatcher.BitBayApi
{
    internal class BitBayClient : IBitBayClient
    {
        private class CurrencyPair
        {
            private readonly Currency _sourceCurrency;
            private readonly Currency _destinationCurrency;

            public CurrencyPair(Currency sourceCurrency, Currency destinationCurrency)
            {
                _sourceCurrency = sourceCurrency;
                _destinationCurrency = destinationCurrency;
            }

            public override bool Equals(object obj)
            {
                var currencyPair = obj as CurrencyPair;
                if (currencyPair == null)
                    return false;

                return currencyPair._sourceCurrency == _sourceCurrency 
                    && currencyPair._destinationCurrency == _destinationCurrency;
            }

            public override int GetHashCode()
            {
                return ((int) _sourceCurrency*397) ^ (int) _destinationCurrency;
            }
        }

        private readonly ICurrencyMetadataService _currencyMetadataService;
        private readonly IHttpRequestService _httpRequestService;
        private readonly ICalculationService _calculationService;

        private readonly Dictionary<CurrencyPair, decimal> _currentExchangeRates = new Dictionary<CurrencyPair, decimal>();

        public BitBayClient(ICurrencyMetadataService currencyMetadataService, IHttpRequestService httpRequestService, ICalculationService calculationService)
        {
            _currencyMetadataService = currencyMetadataService;
            _httpRequestService = httpRequestService;
            _calculationService = calculationService;
        }

        public decimal GetLatestExchangeRate(Currency fromCurrency, Currency toCurrency)
        {
            var currencyPair = new CurrencyPair(fromCurrency, toCurrency);
            if (_currentExchangeRates.ContainsKey(currencyPair))
                return _currentExchangeRates[currencyPair];

            var from = _currencyMetadataService
                .GetCurrencyAbbreviation(fromCurrency);

            var to = _currencyMetadataService
                .GetCurrencyAbbreviation(toCurrency);
            
            var response = _httpRequestService.Get(from, to, "ticker");
            var responseModel = (ResponseModel)JsonConvert.DeserializeObject(response, typeof(ResponseModel));
            var lastExchangeRate = responseModel.Data.Last;

            _currentExchangeRates.Add(currencyPair, lastExchangeRate);

            return lastExchangeRate;
        }

        public decimal GetViableExchangeRate(decimal offerExchangeRate, decimal feeRate)
        {
            return _calculationService.CalculateViableExchangeRate(offerExchangeRate, feeRate);
        }

        public decimal GetProfit(decimal amountSpent, decimal offerExchangeRate, decimal currentExchangeRate, decimal feeRate)
        {
            return _calculationService.CalculateProfit(amountSpent, offerExchangeRate, currentExchangeRate, feeRate);
        }

        public string GetCurrencyName(Currency currency)
        {
            return _currencyMetadataService
                .GetCurrencyName(currency);
        }
    }
}
