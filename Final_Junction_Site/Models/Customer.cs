using System.ComponentModel.DataAnnotations;

namespace Final_Junction_Site.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerPassword { get; set; }

        public string CustomerAddress { get; set; }

        public bool SendEmailNotifications { get; set; }

        public bool SendTextNotifications { get; set; }
    }
}
