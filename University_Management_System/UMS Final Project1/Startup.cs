using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UMS_Final_Project1.Startup))]
namespace UMS_Final_Project1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
