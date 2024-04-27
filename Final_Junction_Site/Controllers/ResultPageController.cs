using Final_Junction_Site.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Final_Junction_Site.Controllers
{
    public class ResultPageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResultPageController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult ResultPage(string searchQuery)
        {
            var sitesQuery = _context.Site.AsQueryable();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                sitesQuery = sitesQuery.Where(site => EF.Functions.Like(site.SiteName, $"%{searchQuery}%") || EF.Functions.Like(site.Tags, $"%{searchQuery}%"));
            }

            var sites = sitesQuery.ToList();

            return View(sites);
        }
    }
}
