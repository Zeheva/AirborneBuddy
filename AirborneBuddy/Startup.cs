using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AirborneBuddy.Startup))]
namespace AirborneBuddy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
