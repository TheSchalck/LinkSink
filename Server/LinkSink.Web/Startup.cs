using Dk.Schalck.LinkSink.Server.LinkSink.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Dk.Schalck.LinkSink.Server.LinkSink.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
