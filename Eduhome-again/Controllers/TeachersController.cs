using Microsoft.AspNetCore.Mvc;

namespace Eduhome_again.Controllers
{
    public class TeachersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
