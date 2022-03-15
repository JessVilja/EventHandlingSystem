using Microsoft.AspNetCore.Mvc;

namespace EventiaWebapp.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Events()
        {
            return View("Events");
        }

        public IActionResult MyEvents()
        {
            return View("MyEvents");
        }
    }
}
