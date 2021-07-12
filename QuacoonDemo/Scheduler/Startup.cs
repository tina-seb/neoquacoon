using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Quacoon.Startup))]
namespace Quacoon
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
