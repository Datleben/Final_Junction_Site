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

            string user  = User.Identity.Name;
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
                    TempData["loginMessage"] = "You have successfully logged in";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["loginErrorMessage"] = "Invalid Email or Password";
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            return View(userInfo);
        }

        //public async Task OnGetAsync(string returnUrl = null)
        //{
        //    if (!string.IsNullOrEmpty(ErrorMessage))
        //    {
        //        ModelState.AddModelError(string.Empty, ErrorMessage);
        //    }

        //    // Clear the existing external cookie
        //    await HttpContext.SignOutAsync(
        //        CookieAuthenticationDefaults.AuthenticationScheme);

        //    ReturnUrl = returnUrl;
        //}
    }
}

