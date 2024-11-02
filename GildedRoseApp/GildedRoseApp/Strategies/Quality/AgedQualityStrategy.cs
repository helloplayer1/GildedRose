using GildedRoseApp.Entities;
using GildedRoseApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseApp.Strategies.Quality
{
    public class AgedQualityStrategy : IQualityStrategy
    {
        private const int MAX_QUALITY = 50;
        public void UpdateQuality(Product product)
        {
            if(product.Quality >= MAX_QUALITY)
            {
                return;
            }

            product.Quality++;
        }
    }
}
