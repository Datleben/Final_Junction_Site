using System;
using System.Collections.Generic;

namespace Final_Junction_Site.Models
{
    public class FakeSiteRepository : ISiteRepository
    {
        public IEnumerable<Site> Sites => new List<Site> {
            new Site{ SiteId = 1, SiteName = "FIRST SITE", ThumbnailURL = "/Images/Book.png", URL = "https://localhost:7289/Home",Description = "this is a site", TrendScore = 5, Tags = "exists"  },
            new Site{ SiteId = 2, SiteName = "second site", ThumbnailURL = "/Images/makeup.png", URL = "https://localhost:7289/Home",Description = "there is no site, this sucks", TrendScore = 1, Tags = "reallyreal"  }
        };
    }
}
