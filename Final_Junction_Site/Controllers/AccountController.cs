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
        //public AccountController()
        //{
        //    customer = new Customer {
        //        CustomerId = 1,CustomerName = "firsname lastname", CustomerEmail = "cusomteremail@gmail.com",
        //        CustomerPassword = "Password", CustomerAddress = "homeAddress", SendEmailNotifications = false, SendTextNotifications = true
        //    };
        //}
        // THIS SECTION IS COMMENTED SO BELOW ACCOUNT CONTROLLER CLASS CONSTRUCTOR TAKES PRIMARY

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
            return View("CreateAccount");
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userService.RegisterUser(customer);
                    //Uncomment above when _userService error Interface issue is resolved
                    return RedirectToAction("Login", "Account");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Registration failed: {ex.Message}");
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
        public async Task<IActionResult> AccountDetails()
        {
            string userName = User.Identity.Name;
            var customer = await _userService.GetUserByName(userName);
            if (customer == null)
            {
                return View("Error"); // Consider a more suitable response here.
            }
            return View("Details", customer); // Pass a single Customer object instead of a list.
        }


    }
}

