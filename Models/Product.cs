﻿namespace TestApp.Models
{
    public class Product
    {
        public Product(bool stack = true)
        {
            InStock = stack;
        }
        public string Name { get; set; }
        public string Category { get; set; } = "Watersports";
        public decimal? Price { get; set; }
        public Product Related { get; set; }
        public bool InStock { get; }
        public bool NameBeginsWithS => Name?[0] == 'S';
        public static Product[] GetProducts()
        {
            Product kayak = new Product
            {
                Name = "Kayak", 
                Category = "Water Craft",
                Price = 275M
            };
            Product lifeJacket = new Product(false)
            {
                Name = "LifeJacket",
                Price = 48.95M
            };

            kayak.Related = lifeJacket; ;

            return new Product[] { kayak, lifeJacket, null };
        }
    }
}
