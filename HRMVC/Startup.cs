using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRMVC.Startup))]
namespace HRMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
