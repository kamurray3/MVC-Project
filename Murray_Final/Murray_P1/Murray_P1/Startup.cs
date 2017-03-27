using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Murray_P1.Startup))]
namespace Murray_P1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
