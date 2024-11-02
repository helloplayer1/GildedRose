using GildedRoseApp.Entities;
using GildedRoseApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseApp.Strategies.Price
{
    public class PercentagePriceDiscountStrategy : IPriceStrategy
    {
        private decimal DiscountPercentage { get; init; }

        public PercentagePriceDiscountStrategy(decimal discountPercentage)
        {
            DiscountPercentage = discountPercentage;

            if (DiscountPercentage < 0 || DiscountPercentage > 1)
            {
                throw new ArgumentException("Discount percentage must be between 0 and 1");
            }
        }
        public decimal CalculatePrice(Product product, decimal interimPrice)
        {
            return interimPrice * (1 - DiscountPercentage);
        }
    }
}
