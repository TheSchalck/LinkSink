using System.Web.Mvc;

namespace Dk.Schalck.LinkSink.Server.LinkSink.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
