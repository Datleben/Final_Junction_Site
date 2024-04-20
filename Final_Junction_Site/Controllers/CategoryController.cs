using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Final_Junction_Site.Models; // Ensure this namespace correctly refers to where your models are defined

namespace Final_Junction_Site.Controllers
{
    public class CategoryController : Controller
    {
        private static List<CategoryProductModel> _products = new List<CategoryProductModel>
        {
            // Sample data
            new CategoryProductModel { ProductId = 1, Name = "Product 1", Price = 9.99m, TrendScore = 5, Category = "Electronics" },
            new CategoryProductModel { ProductId = 2, Name = "Product 2", Price = 19.99m, TrendScore = 15, Category = "Electronics" },
            
        };

        public IActionResult CategoryProducts(string category)
        {
            var filteredProducts = _products.Where(p => p.Category == category).OrderByDescending(p => p.TrendScore).ToList();
            return View(filteredProducts);
        }
    }
}
