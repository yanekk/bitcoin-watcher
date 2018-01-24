using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BitCoinWatcher.BitBayApi;
using BitCoinWatcher.BitBayApi.Enums;
using BitCoinWatcher.Models.Currencies;

namespace BitCoinWatcher.Controllers.Api
{
    [RoutePrefix("currency")]
    public class CurrencyApiController : ApiController
    {
        private readonly IBitBayClient _bitBayClient;

        public CurrencyApiController(IBitBayClient bitBayClient)
        {
            _bitBayClient = bitBayClient;
        }

        [HttpGet, Route("")]
        public List<CurrencyViewModel> GetAll()
        {
            return Enum.GetValues(typeof(Currency))
                .Cast<Currency>()
                .Where(currency => currency != Currency.Pln)
                .Select(currency => new CurrencyViewModel
                {
                    Id = (int) currency,
                    Name = _bitBayClient.GetCurrencyName(currency)
                })
                .ToList();
        }
    }
}