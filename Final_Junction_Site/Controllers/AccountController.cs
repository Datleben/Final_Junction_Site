using Final_Junction_Site.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Final_Junction_Site.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private Customer customer;

        private readonly IUserService _userService;

        public AccountController(IUserService userService, ApplicationDbContext context)
        {
            _userService = userService;
            _context = context;
        }

        public ViewResult Details()
        {
            return View();
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Customer customer)
        {
                if (ModelState.IsValid)
                {
                    var newCustomer = new Customer
                    {
                        CustomerName = customer.CustomerName,
                        CustomerEmail = customer.CustomerEmail,
                        CustomerPassword = customer.CustomerPassword,
                        CustomerAddress = customer.CustomerAddress
                    //ADD THE PROMOTIONAL PREFERENCE MESSAGE ALONG WITH THE NEW CUSTOMER? 
                    };

                    var result = await _userService.RegisterUser(newCustomer);

                    if (result)
                    {
                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        // Handle registration failure
                        ModelState.AddModelError("", "An error occurred while registering the user.");
                    }
                }

                return View(customer);
            }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // GET: /Account/Details
        [HttpGet("Account/Details")]
        public IActionResult AccountDetails()
        {
            var customers = _context.Customer.ToList(); // Fetches all customer records from the database
            return View("Details", customers); 
        }

    }
}

