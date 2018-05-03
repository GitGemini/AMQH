using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AMQH.Startup))]
namespace AMQH
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
