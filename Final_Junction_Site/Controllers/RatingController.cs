using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Junction_Site.Models;
using Microsoft.AspNetCore.Mvc;
using Final_Junction_Site.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using SportsStore.Models;
using Microsoft.AspNetCore.Authorization;

namespace Final_Junction_Site.Controllers
{
    public class RatingController : Controller
    {
        private IRatingRepository repositoryR;
		private ICustomerRepository repositoryC;
        private UserManager<AppUser> userManager;
        public int PageSize = 4;
        public RatingController(IRatingRepository repoR, ICustomerRepository repoC, UserManager<AppUser> userMgr)
        {
            repositoryR = repoR;
            repositoryC = repoC;
            userManager = userMgr;
        }

        public ViewResult List(int siteId, int page = 1)
        {
            return View(
            new RatingListViewModel
            {
                Ratings = repositoryR.Ratings
                    .Where(r => r.SiteId == siteId).OrderBy(r => r.RatingId).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    CurrentSiteId = siteId,
                    ItemsPerPage = PageSize,
                    TotalItems = repositoryR.Ratings.Where(r => r.SiteId == siteId).Count()
                },
                Customers = repositoryC.Customers
            });
        }

        //public ViewResult Edit(int RatingId) => View(repository.Ratings.FirstOrDefault(r => r.RatingId == RatingId));
        [Authorize]
        public async Task<IActionResult> Create(int siteId)
        {
            AppUser user = await userManager.GetUserAsync(User);
            int customerId = user.customerId;
            Rating customerSiteReview = repositoryR.Ratings.FirstOrDefault(r => r.CustomerId == customerId && r.SiteId == siteId );

            ViewBag.CustomerId = customerId;
            ViewBag.SiteId = siteId;
            if (customerSiteReview is not null)
            {
                return View("Edit", customerSiteReview);
            }
            else {
                return View("Edit", new Rating());
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(Rating rating, int routingSiteId)
        {
            if (ModelState.IsValid)
            {
				repositoryR.SaveRating(rating);
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
