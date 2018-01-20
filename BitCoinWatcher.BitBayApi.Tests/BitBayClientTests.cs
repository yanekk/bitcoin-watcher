using BitCoinWatcher.BitBayApi.Enums;
using BitCoinWatcher.BitBayApi.Services;
using Moq;
using NUnit.Framework;

namespace BitCoinWatcher.BitBayApi.Tests
{
    [TestFixture]
    public class BitBayClientTests
    {
        [Test]
        public void LatestExchangeIsParsedCorrectly()
        {
            var currencyMetadataServiceMock = new Mock<ICurrencyMetadataService>();
            currencyMetadataServiceMock
                .Setup(s => s.GetCurrencyAbbreviation(It.IsAny<Currency>()))
                .Returns("BTC");
            var httpServiceMock = new Mock<IHttpRequestService>();
            httpServiceMock.Setup(s => s.Get(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns("{\"request\":\"ticker\",\"data\":{\"last\":\"41559.31\"},\"code\":200,\"status\":\"Success\"} ");
            
            var client = new BitBayClient(currencyMetadataServiceMock.Object, httpServiceMock.Object, new Mock<ICalculationService>().Object);
            var currentExchange = client.GetLatestExchangeRate(Currency.Pln, Currency.Bitcoin);
            Assert.AreEqual(41559.31m, currentExchange);
        }

        [Test]
        public void SecondExchangeCallIsReturnedFromCache()
        {
            var currencyMetadataServiceMock = new Mock<ICurrencyMetadataService>();
            currencyMetadataServiceMock
                .Setup(s => s.GetCurrencyAbbreviation(It.IsAny<Currency>()))
                .Returns("BTC");

            var callsCount = 0;
            var httpServiceMock = new Mock<IHttpRequestService>();
            httpServiceMock.Setup(s => s.Get(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Callback<string, string, string>((a, b, c) => { callsCount++; })
                .Returns("{\"request\":\"ticker\",\"data\":{\"last\":\"41559.31\"},\"code\":200,\"status\":\"Success\"} ");

            var client = new BitBayClient(currencyMetadataServiceMock.Object, httpServiceMock.Object, new Mock<ICalculationService>().Object);
            client.GetLatestExchangeRate(Currency.Pln, Currency.Bitcoin);
            client.GetLatestExchangeRate(Currency.Pln, Currency.Bitcoin);
            
            Assert.AreEqual(1, callsCount);
        }
    }
}
