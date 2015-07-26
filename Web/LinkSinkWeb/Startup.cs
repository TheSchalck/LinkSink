using Dk.Schalck.LinkSink.Web.LinkSinkWeb;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace Dk.Schalck.LinkSink.Web.LinkSinkWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
