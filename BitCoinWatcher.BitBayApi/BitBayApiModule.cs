using System.Reflection;
using Autofac;
using BitCoinWatcher.BitBayApi.CurrencyMetadata;
using BitCoinWatcher.BitBayApi.Services;
using Module = Autofac.Module;

namespace BitCoinWatcher.BitBayApi
{
    public class BitBayApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var thisAssembly = Assembly.GetExecutingAssembly();

            builder
                .RegisterAssemblyTypes(thisAssembly)
                .AssignableTo<ICoreService>()
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder
                .RegisterAssemblyTypes(thisAssembly)
                .AssignableTo<ICurrencyMetadata>()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder
                .RegisterType<BitBayClient>()
                .As<IBitBayClient>()
                .InstancePerRequest();
        }
    }
}
