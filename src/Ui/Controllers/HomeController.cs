using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Akka.Actor;
using Core;
using Core.Actors;
using Core.Messages;

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
            ViewBag.Posts = await _systemActors.DomainModels.Ask<List<Post>>(new GetPosts(), TimeSpan.FromSeconds(1));

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
