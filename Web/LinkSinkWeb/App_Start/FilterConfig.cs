using System.Web.Mvc;

namespace Dk.Schalck.LinkSink.Web.LinkSinkWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
