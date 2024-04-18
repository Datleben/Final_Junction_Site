
namespace Final_Junction_Site.Models
{
    public class TestDBRepository : ITestDBRepository
    {
        public ApplicationDbContext context;
        public TestDBRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<TestDBClass> TestDBClasses => context.TestDBClass;
    }
}

//NOT IN USE