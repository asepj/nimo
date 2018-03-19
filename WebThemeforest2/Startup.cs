using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebThemeforest2.Startup))]
namespace WebThemeforest2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
