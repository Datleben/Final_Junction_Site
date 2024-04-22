using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Final_Junction_Site.Models;

namespace Final_Junction_Site.Controllers
{
    public class CategoryController : Controller
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


        public CategoryController(IWebHostEnvironment environment)
        {

        }
        public IActionResult CategoryProducts(string category, string sortOrder, decimal? minPrice, decimal? maxPrice)
        {
            ViewBag.Category = category;
            var filteredProducts = _products.Where(p => p.Category == category);



            var test = filteredProducts.Count();

            // Apply price filters only if both minPrice and maxPrice are provided
            if (minPrice.HasValue && maxPrice.HasValue)
            {
                filteredProducts = filteredProducts.Where(p => p.Price >= minPrice.Value && p.Price <= maxPrice.Value);
            }

            switch (sortOrder)
            {
                case "priceLowHigh":
                    filteredProducts = filteredProducts.OrderBy(p => p.Price);
                    break;
                case "priceHighLow":
                    filteredProducts = filteredProducts.OrderByDescending(p => p.Price);
                    break;
                case "newest":
                    filteredProducts = filteredProducts.OrderByDescending(p => p.DateAdded);
                    break;
                default:
                    // filteredProducts = filteredProducts.OrderByDescending(p => p.TrendScore);
                    break;
            }

            return View(filteredProducts.ToList());
        }

    }
}
