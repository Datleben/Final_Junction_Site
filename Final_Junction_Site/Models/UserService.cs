﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using Junction.Data;
using Final_Junction_Site.Models;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddUser(Customer customer)
    {
        _context.Customer.Add(customer);
        // _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
    }

    public async Task<Customer> GetUserByUsernameAndPassword(string username, string password)
    {
        return await _context.Customer.FirstOrDefaultAsync(u => u.CustomerName == username && u.CustomerPassword == password);
        // return await _context.Customers.FirstOrDefaultAsync(u => u.CustomerName == username && u.CustomerPassword == password);
    }

    public async Task<Customer> GetUserByEmail(string email)
    {
        return await _context.Customer.FirstOrDefaultAsync(u => u.CustomerEmail == email);
        //return await _context.Customers.FirstOrDefaultAsync(u => u.CustomerEmail == email);
    }

    public async Task ResetPassword(string token, string newPassword)
    {
        // Implement password reset logic (e.g., find user by token and update password)
        throw new NotImplementedException();
    }

    Task IUserService.RegisterUser(Customer customer)
    {
        throw new NotImplementedException();
    }

    Task<Customer> IUserService.AuthenticateUser(string username, string password)
    {
        throw new NotImplementedException();
    }

    Task IUserService.SendPasswordResetEmail(string email)
    {
        throw new NotImplementedException();
    }

    Task IUserService.ResetPassword(string token, string newPassword)
    {
        throw new NotImplementedException();
    }
}
