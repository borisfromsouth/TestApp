using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Controllers.Home
{
    public class HomeController : Controller
    {
        bool FilterByPrice(Product p)
        {
            return (p?.Price ?? 0) >= 20;
        }

        public ViewResult Index()  // как4 варик public ViewResult Index() => View (Product.GetProducts().Select(p => p?.Name))
        {
            //string[] names = new string[3];
            //names[0] = "Bob";
            //names[1] = "Joe";
            //names[2] = "Alice";
            //return View("Index", new string[]{ "Bob", "Joe", "Alice" });

            //Dictionary<string, Product> products = new Dictionary<string, Product>
            //{
            //    ["Kayak"] = new Product { Name = "Kayak", Price = 275M },
            //    ["LifeJacket"] = new Product { Name = "LifeJacket", Price = 48.95M }
            //};
            //return View("Index", products.Keys);

            //object[] data = new object[] { 275M, 29.95M, "apple", "orange", 100, 10 };
            //decimal total = 0;
            //for (int i = 0; i < data.Length; i++)
            //{
            //    if (data[i] is decimal d)
            //    {
            //        total += d;
            //    }
            //}
            //return View("Index", new string[] {$"Total: {total:C2}"});   // похоже с2 формат доллоров

            //object[] data = new object[] { 275M, 29.95M, "apple", "orange", 100, 10 };
            //decimal total = 0;
            //for (int i = 0; i < data.Length; i++)
            //{
            //    switch (data[i])   // молжно сделать кейс по типу объекта
            //    {
            //        case decimal decimalValue:
            //            total += decimalValue;
            //            break;
            //        case int intValue when intValue > 50:   // when для дополнительной избирательности 
            //            total += intValue;
            //            break;
            //    }
            //}
            //return View("Index", new string[] { $"Total: {total:C2}" });   // похоже с2 формат доллоров

            //ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };
            //decimal cartTotal = cart.TotalPrices();
            //return View("Index", new string[] { $"Total: {cartTotal:C2}" });

            //ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };
            //Product[] productArray =
            //{
            //    new Product{ Name = "Kayak", Price = 275M },
            //    new Product{ Name = "LifeJacket", Price = 48.95M }
            //};
            //decimal cartTotal = cart.TotalPrices();
            //decimal arrayTotal = productArray.TotalPrices();
            //return View("Index", new string[] { $"Cart Total: {cartTotal:C2}", $"Array Total: {arrayTotal:C2}" });

            //Product[] productArray =
            //{
            //    new Product{ Name = "Kayak", Price = 275M },
            //    new Product{ Name = "LifeJacket", Price = 48.95M },
            //    new Product{ Name = "Soccer ball", Price = 19.50M },
            //    new Product{ Name = "Corner Flag", Price = 34.95M }
            //};
            //decimal arrayTotal = productArray.FilterByPrice(20).TotalPrices();
            //return View("Index", new string[] { $"Array Total: {arrayTotal:C2}" });

            //Product[] productArray =
            //{
            //    new Product{ Name = "Kayak", Price = 275M },
            //    new Product{ Name = "LifeJacket", Price = 48.95M },
            //    new Product{ Name = "Soccer ball", Price = 19.50M },
            //    new Product{ Name = "Corner Flag", Price = 34.95M }
            //};
            //decimal priceFilterTotal = productArray.FilterByPrice(20).TotalPrices();
            //decimal nameFilterTotal = productArray.FilterByName('S').TotalPrices();
            //return View("Index", new string[] { $"Price Total: {priceFilterTotal:C2}", $"Name Total: {nameFilterTotal:C2}" });

            //Product[] productArray =
            //{
            //    new Product{ Name = "Kayak", Price = 275M },
            //    new Product{ Name = "LifeJacket", Price = 48.95M },
            //    new Product{ Name = "Soccer ball", Price = 19.50M },
            //    new Product{ Name = "Corner Flag", Price = 34.95M }
            //};
            //Func<Product, bool> nameFilter = delegate (Product prod)
            //{
            //    return prod?.Name?[0] == 'S';
            //};
            //decimal priceFilterTotal = productArray.Filter(p => (p?.Price ?? 0) >= 20).TotalPrices();
            //decimal nameFilterTotal = productArray.Filter(p => p?.Name? [0] == 'S').TotalPrices();
            //return View("Index", new string[] { $"Price Total: {priceFilterTotal:C2}", $"Name Total: {nameFilterTotal:C2}" });

            //return View(Product.GetProducts().Select(p => p?.Name));

            //var names = new[] { "Kayak", "Lifejacket", "Soccer ball" };
            //return View(names);

            //var products = new[]
            //{
            //        new { Name = "Kayak", Price = 275M },
            //        new { Name = "LifeJacket", Price = 48.95M },
            //        new { Name = "Soccer ball", Price = 19.50M },
            //        new { Name = "Corner Flag", Price = 34.95M }
            //    };
            //return View(products.Select(p => p.GetType().Name));

            var products = new[]
            {
                    new { Name = "Kayak", Price = 275M },
                    new { Name = "LifeJacket", Price = 48.95M },
                    new { Name = "Soccer ball", Price = 19.50M },
                    new { Name = "Corner Flag", Price = 34.95M }
                };
            return View(products.Select(p => $"{nameof(p.Name)}: {p.Name}, {nameof(p.Price)}: {p.Price}")) ;

            List<string> results = new List<string>();
            foreach (Product p in Product.GetProducts())
            {
                string name = p?.Name ?? "<No Name>";
                decimal? price = p?.Price ?? 0;
                string category = p?.Category ?? "<None>";
                string relatedName = p?.Related?.Name ?? "<None>";
                bool? stock = p?.InStock ?? false;
                results.Add(string.Format($"Name: {name} , Price: {price} , Category: {category} , Related: {relatedName} , In stock: {stock}"));
            }
            return View(results);
        }

        //public async Task<ViewResult> Index()
        //{
        //    long? length = await MyAsyncMethods.GetPageLength();
        //    return View(new string[] { $"Length: {length}" });
        //}
    }
}
