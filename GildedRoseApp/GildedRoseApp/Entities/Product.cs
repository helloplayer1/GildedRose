using GildedRoseApp.Interfaces;

namespace GildedRoseApp.Entities
{
    public class Product(
        string name, 
        int sellInDays, 
        int quality,
        decimal basePrice,
        List<IPriceStrategy> priceStrategies, 
        IQualityStrategy qualityStrategy)
    {
        public string Name { get; init; } = name;

        public int SellInDays { get; set; } = sellInDays;

        public int Quality { get; set; } = quality;

        public decimal BasePrice { get; set; } = basePrice;

        public List<IPriceStrategy> PriceStrategies { get; init; } = priceStrategies;

        public IQualityStrategy QualityStrategy { get; init; } = qualityStrategy;

        public decimal GetPrice(Currency currency)
        {
            if(PriceStrategies.Count == 0)
            {
                return currency.ConvertTo(BasePrice);
            }

            return currency.ConvertTo(PriceStrategies.Aggregate(
            BasePrice,
            (result, strategy) => strategy.CalculatePrice(this, result)));
        }

        public void UpdateQuality()
        {
            if(QualityStrategy == null)
            {
                return;
            }

            QualityStrategy.UpdateQuality(this);
            
            if (Quality < 0)
            {
                Quality = 0;
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}, SellInDays: {SellInDays}, Quality: {Quality}, Price: {GetPrice(Currency.EUR_BASE):F2}";
        }

    }
}
