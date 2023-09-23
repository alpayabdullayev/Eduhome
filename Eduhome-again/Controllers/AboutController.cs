using Eduhome_again.DAL;
using Eduhome_again.Models;
using Eduhome_again.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Eduhome_again.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _db;

        public AboutController(AppDbContext db)
        {
            _db=db;
        }
        public async Task<IActionResult>  Index()
        {
            AboutVM aboutVM = new AboutVM()
            {
                Abouts = await _db.Abouts.FirstAsync(),
                Testimonials = await _db.Testimonials.ToListAsync(),

                

            };
            return View(aboutVM);
        }
    }
}
