using Eduhome_again.DAL;
using Eduhome_again.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eduhome_again.Controllers
{
    public class CoursesController : Controller
    {
        private readonly AppDbContext _db;

        public CoursesController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult>  Index()
        {
            List<Course> courses =await _db.Courses.ToListAsync();
            return View(courses);
        }
    }
}
