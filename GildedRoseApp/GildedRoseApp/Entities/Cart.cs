using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GildedRoseApp.Interfaces;

namespace GildedRoseApp.Entities
{
    public class Cart(List<Product> products, List<ICartDiscountStrategy>? discountStrategies)
    {

        public List<Product> Products { get; init; } = products;
        public List<ICartDiscountStrategy>? DiscountStrategies { get; init; } = discountStrategies;

        public decimal GetTotalPrice(Currency currency)
        {
            if(Products.Count == 0)
            {
                return 0;
            }

            decimal totalValue = Products.Aggregate(
                0m,
                (result, product) => result + product.GetPrice(currency)
            );

            if(DiscountStrategies == null || DiscountStrategies.Count == 0)
            {
                return totalValue;
            }

            return DiscountStrategies.Aggregate(
                totalValue,
                (result, strategy) => strategy.CalculateDiscountedPrice(this, result)
            );
        }
    }
}
