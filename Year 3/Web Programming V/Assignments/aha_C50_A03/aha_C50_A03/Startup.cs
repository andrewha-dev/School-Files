using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(aha_C50_A03.Startup))]
namespace aha_C50_A03
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
