using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JJDev.SoftHost.Web.Startup))]
namespace JJDev.SoftHost.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
