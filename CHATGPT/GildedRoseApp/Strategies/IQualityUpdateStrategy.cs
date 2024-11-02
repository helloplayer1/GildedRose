using GildedRoseApp.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseApp.Strategies
{
    internal interface IQualityUpdateStrategy
    {
        void UpdateQuality(Product product);
        void HandleExpiration(Product product);
    }
}
