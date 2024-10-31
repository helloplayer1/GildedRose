using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseApp.Services
{
    internal class PricingService
    {
        private readonly Dictionary<string, decimal> currencyRates;
        private readonly decimal discountRate;

        public PricingService(Dictionary<string, decimal> currencyRates, decimal discountRate)
        {
            this.currencyRates = currencyRates;
            this.discountRate = discountRate;
        }

        public decimal ConvertPrice(decimal price, string targetCurrency)
        {
            return currencyRates.ContainsKey(targetCurrency) ? price * currencyRates[targetCurrency] : price;
        }

        public decimal ApplyDiscount(decimal price, int quantity)
        {
            return quantity >= 10 ? price * (1 - discountRate) : price;
        }
    }
}
