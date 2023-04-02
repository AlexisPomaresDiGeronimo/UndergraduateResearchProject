using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Undergraduate_Aliveri_Web_App_Project.Startup))]
namespace Undergraduate_Aliveri_Web_App_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
