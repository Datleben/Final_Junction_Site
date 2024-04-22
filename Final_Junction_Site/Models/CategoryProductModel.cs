namespace Final_Junction_Site.Models
{
    public class CategoryProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int TrendScore { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public bool IsNew { get; set; }
        public bool OnSale { get; set; }
        public int Rating { get; set; }
    }
}
