using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SOA.Web.Startup))]
namespace SOA.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
