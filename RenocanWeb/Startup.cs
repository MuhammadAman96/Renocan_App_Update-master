using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RenocanWeb.Startup))]
namespace RenocanWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
