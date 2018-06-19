using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zork2.Startup))]
namespace Zork2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
