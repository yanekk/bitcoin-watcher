using BitCoinWatcher.BitBayApi.Services;
using NUnit.Framework;

namespace BitCoinWatcher.BitBayApi.Tests
{
    [TestFixture]
    internal class CalculationServiceTests
    {
        private ICalculationService CreateService()
        {
            return new CalculationService();
        }

        [Test]
        public void IsViableExchangeRateCalculatedCorrectly()
        {
            var offerExchangeRate = 869.96m;
            var feeRate = 0.0043m;

            var expectedViableExchangeRate = 877.47m;
            var actualViableExchangeRate = CreateService().CalculateViableExchangeRate(offerExchangeRate, feeRate);

            Assert.AreEqual(expectedViableExchangeRate, actualViableExchangeRate);
        }

        [Test]
        public void IsProfitCalculatedCorrectly()
        {
            var amountSpent = 150.0m;
            var offerExchangeRate = 3865m;
            var currentExchangeRate = 3804m;
            var feeRate = 0.0043m;

            var expectedProfit = -3.63m;
            var actualProfit = CreateService().CalculateProfit(amountSpent, offerExchangeRate, currentExchangeRate, feeRate);
            Assert.AreEqual(expectedProfit, actualProfit);
        }
    }
}
