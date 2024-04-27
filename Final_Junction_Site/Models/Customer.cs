using System.ComponentModel.DataAnnotations;

namespace Final_Junction_Site.Models
{
    public class Customer
    {
        public int Customer_Id { get; set; }

        public string Customer_Name { get; set; }

        public string Customer_Email { get; set; }

        public string Customer_Password { get; set; }

        public string Customer_Address { get; set; }

        public bool SendEmailNotifications { get; set; }

        public bool SendTextNotifications { get; set; }
    }
}
