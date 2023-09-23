using Eduhome_again.DAL;
using Eduhome_again.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eduhome_again.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServicesController : Controller
    {
        private readonly AppDbContext _db;

        public ServicesController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult>  Index()
        {
            List<Service> services = await _db.Services.ToListAsync();
            return View(services);
        }

        public IActionResult Create() 
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Service service)
        {

            if (!ModelState.IsValid) 
            {
                return View();
            }
            await  _db.Services.AddAsync(service);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

