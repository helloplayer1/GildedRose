using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseApp.Entities
{
    public class Simulation(List<Product> products, Cart cart, List<Currency> currencies)
    {
        public List<Product> Products { get; init; } = products;

        public Cart Cart { get; init; } = cart;

        public List<Currency> Currencies { get; init; } = currencies;

        public void NextDay()
        {
            foreach (var product in Products)
            {
                product.SellInDays--;
                product.UpdateQuality();
            }
        }
    }
}
