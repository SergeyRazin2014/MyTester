using System.Web.Mvc;

namespace MyTester.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("~/app");
        }
    }
}