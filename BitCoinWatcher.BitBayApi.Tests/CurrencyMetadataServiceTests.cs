using System.Collections.Generic;
using BitCoinWatcher.BitBayApi.CurrencyMetadata;
using BitCoinWatcher.BitBayApi.Enums;
using BitCoinWatcher.BitBayApi.Services;
using Moq;
using NUnit.Framework;

namespace BitCoinWatcher.BitBayApi.Tests
{
    [TestFixture]
    internal class CurrencyMetadataServiceTests
    {
        private ICurrencyMetadataService GetCurrencyMetadataService()
        {
            var currencyMetadataMock = new Mock<ICurrencyMetadata>();
            currencyMetadataMock.SetupGet(m => m.Currency).Returns(Currency.Bitcoin);
            currencyMetadataMock.SetupGet(m => m.Abbreviation).Returns("BTC");
            currencyMetadataMock.SetupGet(m => m.Name).Returns("Bitcoin");
            return new CurrencyMetadataService(new List<ICurrencyMetadata> {currencyMetadataMock.Object});
        }

        [Test]
        public void IsMetadataExtractedCorrectly()
        {
            var service = GetCurrencyMetadataService();
            Assert.AreEqual("BTC", service.GetCurrencyAbbreviation(Currency.Bitcoin));
            Assert.AreEqual("Bitcoin", service.GetCurrencyName(Currency.Bitcoin));
        }
    }
}
