using System.Threading.Tasks;
using Final_Junction_Site.Models;

public interface IUserService
{
    Task RegisterUser(Customer customer);
    Task<Customer> AuthenticateUser(string username, string password);
    Task SendPasswordResetEmail(string email);
    Task ResetPassword(string token, string newPassword);
}
