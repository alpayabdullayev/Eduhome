using Eduhome_again.DAL;
using Eduhome_again.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;

namespace Eduhome_again.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {

        private readonly AppDbContext _db;
        public HeaderViewComponent(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Header header = await _db.Header.SingleOrDefaultAsync();
            return View(header);
        }

    }
}
