using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DevJobs.Web.Startup))]
namespace DevJobs.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
