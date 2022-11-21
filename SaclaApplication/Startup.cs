using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SaclaApplication.Startup))]
namespace SaclaApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
