using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Final_Junction_Site.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_Junction_Site.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult CategoryProducts(string category, string sortOrder)
        {
            ViewBag.Category = category;

            // Query the database to retrieve sites
            var sitesQuery = _context.Site.AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                // Assuming your Site model has a Tags property where categories are stored
                sitesQuery = sitesQuery.Where(site => EF.Functions.Like(site.Tags, $"%{category}%"));
            }

            // Sort the sites based on the provided sortOrder
            switch (sortOrder)
            {
                case "scoreLowHigh":
                    sitesQuery = sitesQuery.OrderBy(site => site.TrendScore);
                    break;
                case "scoreHighLow":
                    sitesQuery = sitesQuery.OrderByDescending(site => site.TrendScore);
                    break;
                // Add more cases if you have other sorting options
                default:
                    // You might want to have a default sorting, for instance by ID
                    sitesQuery = sitesQuery.OrderBy(site => site.SiteId);
                    break;
            }

            // Execute the query and convert it to a list
            var sites = sitesQuery.ToList();

            return View(sites);
        }
    }
}
