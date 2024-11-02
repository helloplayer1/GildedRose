using GildedRoseApp.Entities;
using GildedRoseApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseApp.Strategies.Quality
{
    public class DefaultQualityStrategy : IQualityStrategy
    {
        public void UpdateQuality(Product product)
        {
            product.Quality--;

            if (product.SellInDays < 0)
            {
                product.Quality--;
            }
        }
    }
}
