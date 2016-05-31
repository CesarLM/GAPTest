using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperZapatosMVC.Startup))]
namespace SuperZapatosMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
