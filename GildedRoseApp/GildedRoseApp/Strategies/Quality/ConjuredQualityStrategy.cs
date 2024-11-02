using GildedRoseApp.Entities;
using GildedRoseApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseApp.Strategies.Quality
{
    public class ConjuredQualityStrategy : IQualityStrategy
    {
        public void UpdateQuality(Product product)
        {
            product.Quality -= 2;

            if (product.SellInDays < 0)
            {
                product.Quality -= 2;
            }
        }
    }
}
