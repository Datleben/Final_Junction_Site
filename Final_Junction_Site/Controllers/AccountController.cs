using Microsoft.AspNetCore.Mvc;

namespace Final_Junction_Site.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Details(
            new Customer{ SiteId = 1,
            )
        {
            return View();
        }
    }
}

Customer_Id { get; set; }

        public string Customer_Name { get; set; }

public string Customer_Email { get; set; }

public string Customer_Password { get; set; }

public string Customer_Address { get; set; }

public bool SendEmailNotifications { get; set; }

public bool SendTextNotifications { get; set; }