using Final_Junction_Site.Models;
using Microsoft.EntityFrameworkCore;
namespace Final_Junction_Site.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //public DbSet<Site> Sites { get; set; }
        public DbSet<TestDBClass> TestDBClass { get; set; } // remove when done testing, and add Sites (above line). Will need to add other tables too
    }
}