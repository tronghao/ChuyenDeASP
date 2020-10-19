using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppMVCStudy.Startup))]
namespace AppMVCStudy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
