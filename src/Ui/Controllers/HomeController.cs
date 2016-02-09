using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Akka.Actor;

namespace Ui.Controllers
{
    public class HomeController : Controller
    {
        private readonly SystemActors _systemActors;

        public HomeController(SystemActors systemActors)
        {
            _systemActors = systemActors;
        }

        public async Task<ActionResult> Index()
        {
            ViewBag.Message = await _systemActors.QueryProcessor.Ask<string>("", TimeSpan.FromSeconds(1));

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
