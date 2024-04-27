using System;
using System.Collections.Generic;

namespace Final_Junction_Site.Models
{
    public class EFRatingRepository : IRatingRepository
    {
        private ApplicationDbContext context;

        public EFRatingRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Rating> Ratings => context.Rating;

		public void SaveRating(Rating rating)
		{
			if (rating.RatingId == 0)
			{
				context.Rating.Add(rating);
			}
			else
			{
				Rating dbEntry = context.Rating.FirstOrDefault(r => r.RatingId == rating.RatingId);
				if (dbEntry != null)
				{
					dbEntry.SiteId = rating.SiteId;
					dbEntry.CustomerId = rating.CustomerId;
					dbEntry.Stars = rating.Stars;
					dbEntry.ReviewText = rating.ReviewText;
				}
			}
			context.SaveChanges();
		}
	}
}
