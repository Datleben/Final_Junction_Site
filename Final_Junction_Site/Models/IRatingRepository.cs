namespace Final_Junction_Site.Models
{
    public interface IRatingRepository
    {
        IEnumerable<Rating> Ratings { get; }
    }
}
