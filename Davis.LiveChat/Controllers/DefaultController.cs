using System.Web.Mvc;

namespace Davis.LiveChat.Web.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {
            return View("_Layout");
        }
    }
}