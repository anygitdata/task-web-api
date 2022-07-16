using System.Web.Mvc;

namespace TaskWebApi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult DebgPatient()
        {
            return View();
        }


        public ActionResult DebgDoctor()
        {
            return View();
        }
    }
}