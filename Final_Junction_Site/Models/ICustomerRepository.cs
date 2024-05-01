namespace Final_Junction_Site.Models
{
	public interface ICustomerRepository
	{
		public IEnumerable<Customer> Customers { get; }

        void SaveCustomer(Customer customer);
    }
}
