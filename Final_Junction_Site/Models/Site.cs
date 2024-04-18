using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Final_Junction_Site.Models;

namespace Final_Junction_Site.Models
{
    public class Site
    {
        public int SiteId { get; set; }
        public int RatingId { get; set; }
        public string SiteName { get; set; }
        public string ThumbnailURL { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public decimal TrendScore{ get; set; }
        public string Tags { get; set; }
    }
}
