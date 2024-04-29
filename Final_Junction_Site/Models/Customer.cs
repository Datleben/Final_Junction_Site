using System.ComponentModel.DataAnnotations;

namespace Final_Junction_Site.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter a username.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Please enter an email address.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
        public string CustomerPassword { get; set; }

        [Required(ErrorMessage = "Please enter an address.")]
        [StringLength(255, ErrorMessage = "Address cannot exceed 255 characters.")]
        public string CustomerAddress { get; set; }

        public bool SendEmailNotifications { get; set; }

        public bool SendTextNotifications { get; set; }

        // Method to validate user credentials
        public bool ValidateCredentials(string username, string password)
        {
            return this.CustomerName == username && this.CustomerPassword == password;
        }

        //public int CustomerId { get; set; }

        //public string CustomerName { get; set; }

        //public string CustomerEmail { get; set; }

        //public string CustomerPassword { get; set; }

        //public string CustomerAddress { get; set; }

        //public bool SendEmailNotifications { get; set; }

        //public bool SendTextNotifications { get; set; }
    }
}
