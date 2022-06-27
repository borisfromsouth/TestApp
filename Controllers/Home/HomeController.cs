﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestApp.Models;

namespace TestApp.Controllers.Home
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            List<string> results = new List<string>();
            foreach (Product p in Product.GetProducts())
            {
                string name = p?.Name;
                decimal? price = p?.Price;
                string relatedName = p?.Related?.Name;
                results.Add(string.Format("Name: {0}, Price: {1}, Related: {2}", name, price, relatedName));
            }
            return View(results);
        }
    }
}