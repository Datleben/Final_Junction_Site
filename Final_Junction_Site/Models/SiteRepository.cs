
namespace Final_Junction_Site.Models
{
    public class SiteRepository : ISiteRepository
    {
        public ApplicationDbContext context;
        public SiteRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Site> Sites => context.Site;
    }
}
