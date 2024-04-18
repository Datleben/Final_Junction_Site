using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Final_Junction_Site.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int SiteId { get; set; }
        public int CustomerId { get; set; }
        public int Stars { get; set; }
        public string ReviewText { get; set; }
    }
}
