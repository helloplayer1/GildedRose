using GildedRoseApp.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseApp.Products
{
    internal class AgedBrie : Product
    {
        private readonly IQualityUpdateStrategy _qualityStrategy = new AgedBrieStrategy();

        public override void UpdateQuality()
        {
            _qualityStrategy.UpdateQuality(this);
            _qualityStrategy.HandleExpiration(this);
        }
    }
}
