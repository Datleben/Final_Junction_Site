using Final_Junction_Site.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Final_Junction_Site.Controllers
{
    public class AccountController : Controller
    {
        private Customer customer;

        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
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
    }
}

