using System.Web.Mvc;

namespace Dk.Schalck.LinkSink.Server.LinkSink.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
