using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GildedRoseApp.Interfaces;

namespace GildedRoseApp.Entities
{
    public class Cart
    {
        public List<Product> Products { get; } = [];
        public List<ICartDiscountStrategy> DiscountStrategies { get; } = [];

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }

        public decimal GetTotalPrice(Currency currency) => Products.Aggregate(
                0m,
                (result, product) => result + product.GetPrice(currency)
            );

    }
}
