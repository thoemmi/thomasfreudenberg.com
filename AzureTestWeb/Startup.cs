using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AzureTestWeb.Startup))]
namespace AzureTestWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
