using Microsoft.AspNetCore.Mvc;

namespace Eduhome_again.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
