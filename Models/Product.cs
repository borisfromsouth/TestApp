namespace TestApp.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; } = "Watersports";
        public decimal? Price { get; set; }
        public Product Related { get; set; }
        public static Product[] GetProducts()
        {
            Product kayak = new Product
            {
                Name = "Kayak", 
                Category = "Water Craft",
                Price = 275M
            };
            Product lifeJacket = new Product
            {
                Name = "lifeJacket",
                Price = 48.95M
            };

            kayak.Related = lifeJacket; ;

            return new Product[] { kayak, lifeJacket, null };
        }
    }
}
