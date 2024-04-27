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
        public RatingController( IRatingRepository repo)
		{
			repository = repo;
		}

        public ViewResult List(int page = 1)
            => View(
            new RatingListViewModel
            {
                Ratings = repository.Ratings
    .               OrderBy(r => r.RatingId)
                    .Skip((page - 1) * PageSize)
    .               Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Ratings.Count()
                }
            });


        //public ViewResult Edit(int RatingId) => View(repository.Ratings.FirstOrDefault(r => r.RatingId == RatingId));
        public ViewResult Create() => View("Edit", new Rating());

        [HttpPost]
        public IActionResult Edit(Rating rating)
        {
            if (ModelState.IsValid)
            {
                repository.SaveRating(rating);
                return RedirectToAction("List");
            }
            else
            {
                // there is something wrong with the data values
                return View(rating);
            }
        }
    }

}
