using Microsoft.AspNetCore.Mvc;

namespace Eduhome_again.Controllers
{
    public class BlogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
