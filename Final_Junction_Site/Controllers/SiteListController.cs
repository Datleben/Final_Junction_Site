using Final_Junction_Site.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Junction_Site.Controllers
{
    public class SiteListController : Controller
    {
        private static List<SiteListModel> _sites = new List<SiteListModel>
        {
            // Sample data
            new SiteListModel { SiteId = 1, Name = "Example Site 1", Location = "New York", AddedDate = DateTime.Now.AddDays(-10) },
            new SiteListModel { SiteId = 2, Name = "Example Site 2", Location = "San Francisco", AddedDate = DateTime.Now.AddDays(-5) },
        };

        public IActionResult ListSites()
        {
            return View(_sites.OrderByDescending(s => s.AddedDate).ToList());
        }
    }
}
