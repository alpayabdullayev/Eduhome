using Microsoft.AspNetCore.Mvc;

namespace Eduhome_again.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
