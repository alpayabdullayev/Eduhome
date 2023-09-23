using Eduhome_again.Models;
using Microsoft.EntityFrameworkCore;

namespace Eduhome_again.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions <AppDbContext> option) : base(option)
        {

        }
        public DbSet<Slider> Sliders{ get; set; }
        public DbSet<Service> Services{ get; set; }
        public DbSet<About> Abouts{ get; set; }


    }
}
