using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TigerTaxOnline.Startup))]
namespace TigerTaxOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
