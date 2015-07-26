using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LinkSinkWeb.Startup))]
namespace LinkSinkWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
