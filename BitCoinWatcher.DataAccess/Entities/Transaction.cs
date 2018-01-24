using System;
using System.ComponentModel.DataAnnotations;
using BitCoinWatcher.BitBayApi.Enums;

namespace BitCoinWatcher.DataAccess.Entities
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        public decimal AmountSpent { get; set; }
        public Currency Currency { get; set; }
        public decimal OfferExchangeRate { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
