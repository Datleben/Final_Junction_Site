using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Final_Junction_Site.Models;

public class UserService : IUserService
{
    private ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    //public async Task<Customer> GetUserByUsernameAndPassword(string username, string password)
    //{
    //    return await _context.Customer.FirstOrDefaultAsync(u => u.CustomerName == username && u.CustomerPassword == password);
    //    // return await _context.Customers.FirstOrDefaultAsync(u => u.CustomerName == username && u.CustomerPassword == password);
    //}

    public async Task<Customer> GetUserByName(string name)
    {
        return await _context.Customer.FirstOrDefaultAsync(u => u.CustomerName == name);
        //OR EMAIL BELOW
        //return await _context.Customers.FirstOrDefaultAsync(u => u.CustomerEmail == email);
    }

    public async Task ResetPassword(string token, string newPassword)
    {
        // Implement password reset logic (e.g., find user by token and update password)
        throw new NotImplementedException();
    }

   async Task<Customer?> IUserService.AuthenticateUser(string email, string password)
    {
        var user = await _context.Customer.FirstOrDefaultAsync(u => u.CustomerEmail == email && u.CustomerPassword == password);

        if (user == null)
        {
            return null;
        }
        return user;
    }

    Task IUserService.SendPasswordResetEmail(string email)
    {
        throw new NotImplementedException();
    }

    Task IUserService.ResetPassword(string token, string newPassword)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RegisterUser(Customer customer)
    {
        try
        {

            //MAYBE INCLUDE CHECKS TO MAKE SURE USER DOESNT EXIST BEFORE? LAST PRIORITY THOUGH

            _context.Customer.Add(customer);
            Console.WriteLine(customer.CustomerId);
            await _context.SaveChangesAsync();
            
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
