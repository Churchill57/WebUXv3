using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gold.MVC.Startup))]
namespace Gold.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
