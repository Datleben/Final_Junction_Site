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
                Customer_Id = 1,Customer_Name = "firsname lastname", Customer_Email = "cusomteremail@gmail.com",
                Customer_Password = "Password", Customer_Address = "homeAddress", SendEmailNotifications = false, SendTextNotifications = true
            };
        }

        public ViewResult Details()
        {
            return View();
        }
    }
}

