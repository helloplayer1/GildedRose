using GildedRoseApp.Products;
using GildedRoseApp.Services;
using System;
using System.Collections.Generic;

namespace GildedRoseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sample currency rates and discount rate for PricingService
            var currencyRates = new Dictionary<string, decimal>
            {
                { "USD", 1.0m },
                { "EUR", 0.85m },
                { "JPY", 110.0m }
            };
            decimal discountRate = 0.1m; // 10% discount for bulk

            // Initialize products
            var products = new List<Product>
            {
                new AgedBrie { Name = "Aged Brie", Quality = 10, SellIn = 5 },
                new BackstagePass { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = 20, SellIn = 15 }
            };

            // Initialize services
            var pricingService = new PricingService(currencyRates, discountRate);
            var gildedRose = new GildedRose(products, pricingService);

            // Update products and print results
            gildedRose.UpdateProducts();
            Console.WriteLine("Product updates completed.");

            // Calculate total cart price in EUR
            decimal total = gildedRose.CalculateCartPrice("EUR", products.Count);
            Console.WriteLine($"Total cart price in EUR: {total}");
        }
    }
}
