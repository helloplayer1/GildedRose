using GildedRoseApp.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseApp.Strategies
{
    internal class AgedBrieStrategy : IQualityUpdateStrategy
    {
        public void UpdateQuality(Product product)
        {
            if (product.Quality < 50) product.Quality++;
            product.SellIn--;
        }

        public void HandleExpiration(Product product)
        {
            if (product.SellIn < 0 && product.Quality < 50) product.Quality++;
        }
    }
}
