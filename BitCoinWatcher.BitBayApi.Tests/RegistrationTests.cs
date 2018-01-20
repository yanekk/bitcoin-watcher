using System.Collections.Generic;
using Autofac;
using BitCoinWatcher.BitBayApi.CurrencyMetadata;
using NUnit.Framework;

namespace BitCoinWatcher.BitBayApi.Tests
{
    [TestFixture]
    internal class RegistrationTests
    {
        [Test]
        public void AreModuleRegistrationsCorrect()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<BitBayApiModule>();
            var container = builder.Build();

            var currencyMetadatas = container.Resolve<IEnumerable<ICurrencyMetadata>>();
            CollectionAssert.IsNotEmpty(currencyMetadatas);
        }
    }
}
