using Eduhome_again.DAL;
using Eduhome_again.Models;
using Eduhome_again.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Eduhome_again.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        
        public async Task<IActionResult>  Index()
        {

            HomeVM homeVM = new HomeVM()
            {
                Services =await _db.Services.ToListAsync(),
                Sliders =await _db.Sliders.ToListAsync(),
                Abouts=await _db.Abouts.FirstAsync(),
                Courses=await _db.Courses.Take(3).ToListAsync(),
                Testimonials = await _db.Testimonials.ToListAsync(),
                
            };
            return View(homeVM);
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
