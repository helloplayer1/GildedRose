using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseApp.Entities
{
    public class Currency(string isoCode, decimal exchangeRate)
    {
        public readonly static Currency EUR_BASE = new("EUR", 1);
        public string IsoCode { get; init; } = isoCode;

        public decimal ExchangeRate { get; set; } = exchangeRate;

        public decimal ConvertTo(decimal amount, Currency? fromCurrency = null) => amount / (fromCurrency ?? EUR_BASE).ExchangeRate * ExchangeRate;
    }
}
