using Eduhome_again.DAL;
using Eduhome_again.Models;
using Eduhome_again.ViewModels;
using Microsoft.AspNetCore.Mvc;
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

        
        public IActionResult Index()
        {

            HomeVM homeVM = new HomeVM()
            {
                Services = _db.Services.ToList(),
                Sliders = _db.Sliders.ToList(),
                Abouts= _db.Abouts.First(),
            };
            return View(homeVM);
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
