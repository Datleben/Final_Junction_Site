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

        public void SaveCustomer(Customer customer)
        {
            if (customer.CustomerId == 0)
            {
                context.Customer.Add(customer);
            }
            else
            {
                Customer dbEntry = context.Customer.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
                if (dbEntry != null)
                {
                    dbEntry.CustomerId = customer.CustomerId;
                    dbEntry.CustomerName = customer.CustomerName;
                    dbEntry.CustomerEmail = customer.CustomerEmail;
                    dbEntry.CustomerPassword = customer.CustomerPassword;
                    dbEntry.CustomerAddress = customer.CustomerAddress;
                    dbEntry.SendTextNotifications = customer.SendTextNotifications;
                    dbEntry.SendEmailNotifications = customer.SendEmailNotifications;
                }
            }
            context.SaveChanges();
        }
    }
}