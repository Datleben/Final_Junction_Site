using System.ComponentModel.DataAnnotations;

namespace Final_Junction_Site.Models
{
    public class Login {
    [Required(ErrorMessage = "Please enter an email.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Please enter a password.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    }
}
