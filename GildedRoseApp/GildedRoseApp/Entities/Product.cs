using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GildedRoseApp.Interfaces;

namespace GildedRoseApp.Entities
{
    public class Product(
        string name, 
        int sellInDays, 
        int quality,
        decimal price,
        int productId, 
        List<IPriceStrategy> priceStrategies, 
        IQualityStrategy qualityStrategy)
    {
        public string Name { get; init; } = name;

        public int SellInDays { get; set; } = sellInDays;

        public int Quality { get; set; } = quality;

        public decimal Price { get; set; } = price;

        public int ProductId { get; set; } = productId;

        public List<IPriceStrategy> PriceStrategies { get; init; } = priceStrategies;

        public IQualityStrategy QualityStrategy { get; init; } = qualityStrategy;

        public decimal GetPrice(Currency currency) => currency.ConvertTo(PriceStrategies.Aggregate(
            Price, 
            (result, strategy) => strategy.CalculatePrice(result)));

        public void UpdateQuality() => QualityStrategy.UpdateQuality(this);
    }
}
