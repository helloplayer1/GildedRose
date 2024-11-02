using GildedRoseApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseTests
{
    [TestFixture]
    public class CurrencyTest
    {
        [Test]
        public void ConvertTo_ShouldConvertAmountCorrectly()
        {
            // Arrange
            var eur = new Currency("EUR", 1);
            var usd = new Currency("USD", 1.2m);
            var amountInEur = 100m;

            // Act
            var amountInUsd = usd.ConvertTo(amountInEur, eur);

            // Assert
            Assert.That(amountInUsd, Is.EqualTo(120m));
        }

        [Test]
        public void ConvertTo_ShouldUseDefaultFromCurrency()
        {
            // Arrange
            var usd = new Currency("USD", 1.2m);
            var amountInEur = 100m;

            // Act
            var amountInUsd = usd.ConvertTo(amountInEur);

            // Assert
            Assert.That(amountInUsd, Is.EqualTo(120m));
        }
    }
}
