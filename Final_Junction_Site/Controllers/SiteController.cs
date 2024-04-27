using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Junction_Site.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Junction_Site.Controllers
{
    public class SiteController : Controller
    {
        private ISiteRepository repository;
        public SiteController(ISiteRepository repo)
        {
            repository = repo;
        }

        public ViewResult Details(int SiteId = 1) =>
			View(repository.Sites.FirstOrDefault(s => s.SiteId == SiteId));
		public ViewResult List()
        {
            var sites = repository.Sites ?? Enumerable.Empty<Site>().ToList();
            return View(sites);
        }
    }
}
