using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Final_Junction_Site.Models
{
    public class Rating
    {
        public int RatingId { get; set; }

		//make hidden
		[Required]
		public int SiteId { get; set; }
		
		//make hidden
		[Required]
		public int CustomerId { get; set; }

		[Required]
		[Range(1, 5, ErrorMessage = "Please enter your ranking of the site from 1 to 5")]
		public int Stars { get; set; }

		[Required(ErrorMessage = "Please explain you thoughts on the site")]
		public string ReviewText { get; set; }
    }
}
