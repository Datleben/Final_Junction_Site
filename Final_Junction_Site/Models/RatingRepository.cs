namespace Final_Junction_Site.Models
{
    public class RatingRepository : IRatingRepository
    {
        public ApplicationDbContext context;
        public RatingRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Rating> Ratings => context.Rating;
    }
}
