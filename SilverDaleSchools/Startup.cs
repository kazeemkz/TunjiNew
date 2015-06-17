using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SilverDaleSchools.Startup))]
namespace SilverDaleSchools
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
