using Final_Junction_Site.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

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
            return View(customer);
        }

        public ViewResult EditPrefs()
        {
            return View("Details",customer);
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
        public async Task<IActionResult> AccountDetails()
        {
            string userName = User.Identity.Name;

            //DAVID: THE SETTING OF DEFAULT USERNAME SHOULDN'T BE NEEDED ANYMORE

            /// ONLY FOR TESTING PURPOSES DELETE
            //if (string.IsNullOrEmpty(userName))
            //{
            //    // Set userName to the default customer's name or ID
            //    userName = "Matthew"; // Assuming "Matthew" is no 1 // 
            //}

            var customer = await _userService.GetUserByName(userName);
            if (customer == null)
            {
                return View("Error");
            }
            return View("Details", customer); // Pass a single Customer object 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login userInfo)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.AuthenticateUser(userInfo.Email, userInfo.Password);

                if (user != null)
                {
                    var claim = new Claim(ClaimTypes.Name, user.CustomerName);
                    var claimsIdentity = new ClaimsIdentity(new[] { claim }, CookieAuthenticationDefaults.AuthenticationScheme);

                    // Create an authentication properties object
                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
                    };

                    // Sign in the user
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    // Redirect to the desired page after successful login
                    TempData["loginActionMessages"] = "You have successfully logged in";
                    return RedirectToAction("Details", "Account");
                }
                else
                {
                    TempData["loginErrorMessage"] = "Invalid Email or Password";
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            return View(userInfo);
        }
        public async Task<IActionResult> Logout()
        {
            // Clear the session or authentication cookie
            if (User.Identity.IsAuthenticated)
            {

                // Or, sign out the user from the authentication cookie
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            TempData["loginActionMessages"] = "You have successfully logged out";
            return RedirectToAction("Index", "Home");
        }
    }
}

