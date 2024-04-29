using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Final_Junction_Site.Models;

namespace Final_Junction_Site.Controllers
{
    public class SiteListController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SiteListController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Added parameters for search and filter
        public async Task<IActionResult> ListSites(string searchTerm = "", string locationFilter = "")
        {
            var sites = from s in _context.Site
                        select s;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                sites = sites.Where(s => s.SiteName.Contains(searchTerm) || s.Description.Contains(searchTerm));
            }

            if (!string.IsNullOrEmpty(locationFilter))
            {
                sites = sites.Where(s => s.Tags.Contains(locationFilter));
            }

            return View(await sites.OrderByDescending(s => s.TrendScore).ToListAsync());
        }
    }
}
