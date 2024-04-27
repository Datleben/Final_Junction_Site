using System.Collections.Generic;
using Final_Junction_Site.Models;

namespace Final_Junction_Site.Models.ViewModels
{
    public class RatingListViewModel
    {
        public IEnumerable<Rating> Ratings { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
