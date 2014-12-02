using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(wwdapp.Startup))]
namespace wwdapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
