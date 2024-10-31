using GildedRoseApp.Products;
using GildedRoseApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseApp
{
    internal class GildedRose
    {
        private readonly IList<Product> products;
        private readonly PricingService pricingService;

        public GildedRose(IList<Product> products, PricingService pricingService)
        {
            this.products = products;
            this.pricingService = pricingService;
        }

        public void UpdateProducts()
        {
            foreach (var product in products)
            {
                product.UpdateQuality();
            }
        }

        public decimal CalculateCartPrice(string currency, int quantity)
        {
            decimal total = products.Sum(product => pricingService.ConvertPrice(product.Quality, currency));
            return pricingService.ApplyDiscount(total, quantity);
        }
    }
}
