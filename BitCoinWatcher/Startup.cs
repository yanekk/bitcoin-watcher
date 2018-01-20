using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BitCoinWatcher.Startup))]
namespace BitCoinWatcher
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
