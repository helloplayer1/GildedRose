using GildedRoseApp.Entities;
using GildedRoseApp.Strategies.CartDiscount;
using GildedRoseApp.Strategies.Price;
using GildedRoseApp.Strategies.Quality;

DefaultQualityStrategy defaultQualityStrategy = new();
AgedQualityStrategy agedQualityStrategy = new();
LegendaryQualityStrategy legendaryQualityStrategy = new();
TicketQualityStrategy ticketQualityStrategy = new();
ConjuredQualityStrategy conjuredQualityStrategy = new();

DefaultPriceStrategy defaultPriceStrategy = new();
PercentageDiscountPriceStrategy percentagePriceDiscountStrategy = new(0.1m); // 10% discount

List<Product> products = [
    new(name:"+5 Dexterity Vest",
    sellInDays:10,
    quality:20,
    basePrice:50m,
    priceStrategies:[defaultPriceStrategy],
    qualityStrategy:defaultQualityStrategy
    ),
    new(name:"Aged Brie",
    sellInDays:2,
    quality:0,
    basePrice:5m,
    priceStrategies:[defaultPriceStrategy, percentagePriceDiscountStrategy],
    qualityStrategy:agedQualityStrategy
    ),
    new(name:"Elixir of the Mongoose",
    sellInDays:5,
    quality:7,
    basePrice:20m,
    priceStrategies:[defaultPriceStrategy],
    qualityStrategy:defaultQualityStrategy
    ),
    new(name:"Sulfuras, Hand of Ragnaros",
    sellInDays:0,
    quality:80,
    basePrice:100m,
    priceStrategies:[defaultPriceStrategy],
    qualityStrategy:legendaryQualityStrategy
    ),
    new(name:"Backstage passes to a TAFKAL80ETC concert",
    sellInDays:15,
    quality:20,
    basePrice:30m,
    priceStrategies:[defaultPriceStrategy],
    qualityStrategy:ticketQualityStrategy
    ),
    new(name:"Conjured Mana Cake",
    sellInDays:3,
    quality:6,
    basePrice:9999m,
    priceStrategies:[defaultPriceStrategy],
    qualityStrategy:conjuredQualityStrategy
    )
];

Cart cart = new(products, [new BulkCartDiscountStrategy(0.1m, 5)]);

List<Currency> currencies = [
    Currency.EUR_BASE,
    new(isoCode:"USD", exchangeRate:0.85m),
    new(isoCode:"GBP", exchangeRate:0.75m)
];

Simulation simulation = new Simulation(products, cart, currencies);

products.ForEach(Console.WriteLine);

Console.WriteLine($"\n\n{new string('-', 50)}");
Console.WriteLine("Simulation started");

for (int day = 0; day < 30; day++)
{
    simulation.NextDay();
    Console.WriteLine($"Day {day + 1} - Total price: {cart.GetTotalPrice(Currency.EUR_BASE):F2} {Currency.EUR_BASE.IsoCode}");
}

Console.WriteLine("Simulation ended");
Console.WriteLine($"{new string('-', 50)}\n\n");


products.ForEach(Console.WriteLine);