using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Identity_1.Startup))]
namespace Identity_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
