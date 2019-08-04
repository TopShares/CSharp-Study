using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ESTM.Web.Startup))]
namespace ESTM.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
