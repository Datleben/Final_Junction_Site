using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Junction_Site.Models;
using Microsoft.AspNetCore.Mvc;
using Final_Junction_Site.Models.ViewModels;

namespace Final_Junction_Site.Controllers
{
    public class RatingController : Controller
    {
        private IRatingRepository repository;
        public int PageSize = 4;
        public RatingController(IRatingRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int siteId, int page = 1)
        {
            return View(
            new RatingListViewModel
            {
                Ratings = repository.Ratings
                    .Where(r => r.SiteId == siteId).OrderBy(r => r.RatingId).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    CurrentSiteId = siteId,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Ratings.Where(r => r.SiteId == siteId).Count()
                }
            });
        }

        //public ViewResult Edit(int RatingId) => View(repository.Ratings.FirstOrDefault(r => r.RatingId == RatingId));
        public ViewResult Create(int siteId)
        {
            ViewBag.SiteId = siteId;
            return View("Edit", new Rating());
        }

        [HttpPost]
        public IActionResult Edit(Rating rating, int routingSiteId)
        {
            if (ModelState.IsValid)
            {
                repository.SaveRating(rating);
                return RedirectToAction("List",new { siteId = routingSiteId });
            }
            else
            {
				ViewBag.SiteId = routingSiteId;
				// there is something wrong with the data values
				return View(rating);
            }
        }
    }
}
