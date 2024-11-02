using GildedRoseApp.Entities;
using GildedRoseApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseApp.Strategies.Quality
{
    public class TicketQualityStrategy : IQualityStrategy
    {
        private const int MAX_QUALITY = 50;
        public void UpdateQuality(Product product)
        {
            if(product.SellInDays <= 0)
            {
                product.Quality = 0;
                return;
            }

            product.Quality++;

            if(product.SellInDays <= 10)
            {
                product.Quality++;
            }

            if (product.SellInDays <= 5)
            {
                product.Quality++;
            }

            if(product.Quality >= MAX_QUALITY)
            {
                product.Quality = MAX_QUALITY;
            }
        }
    }
}
