using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TedEx.Startup))]
namespace TedEx
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
