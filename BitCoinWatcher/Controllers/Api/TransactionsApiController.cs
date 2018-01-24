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
using BitCoinWatcher.Models.Transactions;

namespace BitCoinWatcher.Controllers.Api
{
    [RoutePrefix("transactions")]
    public class TransactionsApiController : ApiController
    {
        private readonly IBitBayClient _bitBayClient;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionsApiController(IBitBayClient bitBayClient, ITransactionRepository transactionRepository)
        {
            _bitBayClient = bitBayClient;
            _transactionRepository = transactionRepository;
        }

        [HttpGet, Route("")]
        public List<TransactionGroupViewModel> GetAll()
        {
            return _transactionRepository.GetAll()
                .GroupBy(t => t.Currency)
                .Select(group => ConvertToViewModel(group.Key, group.AsEnumerable()))
                .ToList();
        }

        [HttpPost, Route("")]
        public HttpResponseMessage AddCoinItem(TransactionFormModel transactionFormModel)
        {
            if (!ModelState.IsValid)
                return ActionContext.Response;

            _transactionRepository.Add(ConvertToEntity(transactionFormModel));
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete, Route("{id}")]
        public HttpResponseMessage RemoveCoinItem(int id)
        {
            var coinItem = _transactionRepository.Get(id);
            if (coinItem == null)
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            _transactionRepository.Remove(coinItem);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        private Transaction ConvertToEntity(TransactionFormModel transactionFormModel)
        {
            return new Transaction
            {
                AddedAt = DateTime.Now,
                AmountSpent = transactionFormModel.AmountSpent,
                Currency = transactionFormModel.Currency,
                OfferExchangeRate = transactionFormModel.OfferExchangeRate
            };
        }

        private TransactionGroupViewModel ConvertToViewModel(Currency currency, IEnumerable<Transaction> transactions)
        {
            const decimal currentFeeRate = 0.0043m;
            var currentExchangeRate = _bitBayClient.GetLatestExchangeRate(Currency.Pln, currency);

            var viewModel = new TransactionGroupViewModel
            {
                Currency = _bitBayClient.GetCurrencyName(currency),
                CurrentExchangeRate = currentExchangeRate
            };

            foreach (var transaction in transactions)
            {
                viewModel.Transactions.Add(new TransactionViewModel
                {
                    Id = transaction.Id,
                    AmountSpent = transaction.AmountSpent,
                    AmountBought = decimal.Round(transaction.AmountSpent / transaction.OfferExchangeRate, 4),
                    OfferExchangeRate = transaction.OfferExchangeRate,
                    ViableExchangeRate = _bitBayClient.GetViableExchangeRate(transaction.OfferExchangeRate, currentFeeRate),
                    Profit = _bitBayClient.GetProfit(transaction.AmountSpent, transaction.OfferExchangeRate, currentExchangeRate, currentFeeRate)
                });
            }
            return viewModel;
        }
    }
}