using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyTwo.Startup))]
namespace VidlyTwo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
