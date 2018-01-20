using System.Reflection;
using Autofac;
using BitCoinWatcher.DataAccess.Repositories.Base;
using Module = Autofac.Module;

namespace BitCoinWatcher.DataAccess
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AssignableTo<IRepository>()
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder
                .RegisterType<BitCoinWatcherDbContext>()
                .As<IBitCoinWatcherDbContext>()
                .InstancePerRequest();
        }
    }
}
