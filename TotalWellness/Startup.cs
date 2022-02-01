using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TotalWellness.Startup))]
namespace TotalWellness
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
