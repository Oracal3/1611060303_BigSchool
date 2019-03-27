using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bigschool.Startup))]
namespace Bigschool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
