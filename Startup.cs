using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assesment.Startup))]
namespace Assesment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
