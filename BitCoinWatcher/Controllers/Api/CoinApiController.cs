using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BitCoinWatcher.BitBayApi;
using BitCoinWatcher.BitBayApi.Enums;
using BitCoinWatcher.DataAccess.Entities;
using BitCoinWatcher.DataAccess.Repositories;
using BitCoinWatcher.Models.CoinItems;

namespace BitCoinWatcher.Controllers.Api
{
    [RoutePrefix("coins")]
    public class CoinApiController : ApiController
    {
        private readonly IBitBayClient _bitBayClient;
        private readonly ICoinItemRepository _coinItemRepository;

        public CoinApiController(IBitBayClient bitBayClient, ICoinItemRepository coinItemRepository)
        {
            _bitBayClient = bitBayClient;
            _coinItemRepository = coinItemRepository;
        }

        [HttpGet, Route("")]
        public List<CoinItemViewModel> GetAll()
        {
            return _coinItemRepository.GetAll()
                .Select(ConvertToViewModel)
                .ToList();
        }

        [HttpPost, Route("")]
        public HttpResponseMessage AddCoinItem(CoinItemFormModel coinItemFormModel)
        {
            if (!ModelState.IsValid)
                return ActionContext.Response;

            _coinItemRepository.Add(ConvertToEntity(coinItemFormModel));
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete, Route("{id}")]
        public HttpResponseMessage RemoveCoinItem(int id)
        {
            var coinItem = _coinItemRepository.Get(id);
            if (coinItem == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            _coinItemRepository.Remove(coinItem);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        private CoinItem ConvertToEntity(CoinItemFormModel coinItemFormModel)
        {
            return new CoinItem
            {
                AddedAt = DateTime.Now,
                AmountSpent = coinItemFormModel.AmountSpent,
                Currency = coinItemFormModel.Currency,
                OfferExchangeRate = coinItemFormModel.OfferExchangeRate
            };
        }

        private CoinItemViewModel ConvertToViewModel(CoinItem coinItem)
        {
            var currentExchangeRate = _bitBayClient
                .GetLatestExchangeRate(Currency.Pln, coinItem.Currency);
            var currentFeeRate = 0.0043m;

            return new CoinItemViewModel
            {
                Id = coinItem.Id,
                Currency = _bitBayClient.GetCurrencyName(coinItem.Currency),
                AmountSpent = coinItem.AmountSpent,
                AmountBought = decimal.Round(coinItem.AmountSpent / coinItem.OfferExchangeRate, 4),
                OfferExchangeRate = coinItem.OfferExchangeRate,
                CurrentExchangeRate = currentExchangeRate,
                ViableExchangeRate = _bitBayClient.GetViableExchangeRate(coinItem.OfferExchangeRate, currentFeeRate),
                Profit = _bitBayClient.GetProfit(coinItem.AmountSpent, coinItem.OfferExchangeRate, currentExchangeRate, currentFeeRate)
            };
        }
    }
}