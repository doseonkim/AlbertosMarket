using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlbertosMarket.Startup))]
namespace AlbertosMarket
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
