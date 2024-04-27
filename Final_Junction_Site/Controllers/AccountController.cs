using Final_Junction_Site.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Junction_Site.Controllers
{
    public class AccountController : Controller
    {
        private Customer customer;
        public AccountController()
        {
            customer = new Customer {
                CustomerId = 1,CustomerName = "firsname lastname", CustomerEmail = "cusomteremail@gmail.com",
                CustomerPassword = "Password", CustomerAddress = "homeAddress", SendEmailNotifications = false, SendTextNotifications = true
            };
        }

        public ViewResult Details()
        {
            return View();
        }
    }
}

