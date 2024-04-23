using Final_Junction_Site.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace Final_Junction_Site.Controllers
{
    public class ResultPageController : Controller
    {
        // TEST : TEST : TEST
        private static List<CategoryProductModel> _products = new List<CategoryProductModel>
        {
            // Electronics category products
            new CategoryProductModel { ProductId = 1, Name = "Smartphone", Price = 299.99m, TrendScore = 80, Category = "Electronics" },
            new CategoryProductModel { ProductId = 2, Name = "Laptop", Price = 999.99m, TrendScore = 70, Category = "Electronics" },
            new CategoryProductModel { ProductId = 3, Name = "Tablet", Price = 199.99m, TrendScore = 65, Category = "Electronics" },
            new CategoryProductModel { ProductId = 4, Name = "Smart Watch", Price = 199.99m, TrendScore = 75, Category = "Electronics" },
            new CategoryProductModel { ProductId = 5, Name = "Bluetooth Headphones", Price = 49.99m, TrendScore = 60, Category = "Electronics" },
            new CategoryProductModel { ProductId = 6, Name = "E-reader", Price = 129.99m, TrendScore = 55, Category = "Electronics" },
    
            // Jeans'n Stuff category products
            new CategoryProductModel { ProductId = 7, Name = "Skinny Jeans", Price = 59.99m, TrendScore = 85, Category = "Clothes" },
            new CategoryProductModel { ProductId = 8, Name = "Denim Jacket", Price = 89.99m, TrendScore = 78, Category = "Clothes" },
            new CategoryProductModel { ProductId = 9, Name = "Leather Belt", Price = 19.99m, TrendScore = 60, Category = "Clothes" },
            new CategoryProductModel { ProductId = 10, Name = "Bootcut Jeans", Price = 59.99m, TrendScore = 65, Category = "Clothes" },
            new CategoryProductModel { ProductId = 11, Name = "Denim Shorts", Price = 29.99m, TrendScore = 70, Category = "Clothes" },
            new CategoryProductModel { ProductId = 12, Name = "Denim Skirt", Price = 39.99m, TrendScore = 72, Category = "Clothes" },
    
            // Home Appliances category products
            new CategoryProductModel { ProductId = 13, Name = "Microwave Oven", Price = 99.99m, TrendScore = 65, Category = "Home Appliances" },
            new CategoryProductModel { ProductId = 14, Name = "Blender", Price = 29.99m, TrendScore = 60, Category = "Home Appliances" },
            new CategoryProductModel { ProductId = 15, Name = "Coffee Maker", Price = 49.99m, TrendScore = 75, Category = "Home Appliances" },
            new CategoryProductModel { ProductId = 16, Name = "Toaster", Price = 24.99m, TrendScore = 55, Category = "Home Appliances" },
            new CategoryProductModel { ProductId = 17, Name = "Electric Kettle", Price = 19.99m, TrendScore = 50, Category = "Home Appliances" },
            new CategoryProductModel { ProductId = 18, Name = "Food Processor", Price = 79.99m, TrendScore = 80, Category = "Home Appliances" }
        };

        //private YourDbContext db = new YourDbContext(); // Replace with actual DbContext

        // GET: ResultPage
        public ActionResult ResultPage(string searchQuery)
        {
            /*
            var products = string.IsNullOrEmpty(searchQuery) ? db.Products.ToList() : db.Products
                             .Where(p => p.Name.Contains(searchQuery) || p.Category.Contains(searchQuery))
                             .ToList();

            return View("ResultPage", products); // Specify the view explicitly
            */
            return Mock(searchQuery);
        }

        private ActionResult Mock(string searchQuery)
        {

            // Filter the mock data based on the search query
            var filteredProducts = string.IsNullOrEmpty(searchQuery) ? _products : _products
                .Where(p => p.Name.ToLower().Contains(searchQuery.ToLower()) || p.Category.ToLower().Contains(searchQuery.ToLower()))
                .ToList();

            return View("ResultPage", filteredProducts); // Return the view with filtered mock products
        }
    }
}
