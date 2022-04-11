using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HubSpot_OAuth_Demo.Startup))]
namespace HubSpot_OAuth_Demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
