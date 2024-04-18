namespace Final_Junction_Site.Models
{
    public class IReviewRepository
    {
        public interface ISiteRepository
        {
            IEnumerable<Rating> Ratings { get; }
        }
    }
}
