using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AgendCont.Startup))]
namespace AgendCont
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
