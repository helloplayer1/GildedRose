using GildedRoseApp.Entities;
using GildedRoseApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseApp.Strategies.Price
{
    public class DefaultPriceStrategy : IPriceStrategy
    {
        public decimal CalculatePrice(Product product, decimal interimPrice)
        {
            return interimPrice * (1 + (product.Quality - 25) / 100m);
        }
    }
}
