using Microsoft.AspNetCore.Mvc;

namespace Eduhome_again.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
