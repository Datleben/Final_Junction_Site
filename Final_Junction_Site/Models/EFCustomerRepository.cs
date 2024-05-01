namespace Final_Junction_Site.Models
{
	public class EFCustomerRepository : ICustomerRepository
	{
		private ApplicationDbContext context;

		public EFCustomerRepository(ApplicationDbContext ctx)
		{
			context = ctx;
		}

		public IEnumerable<Customer> Customers => context.Customer;
	}
}
