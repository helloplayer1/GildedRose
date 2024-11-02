using GildedRoseApp.Entities;
using GildedRoseApp.Interfaces;
using GildedRoseApp.Strategies.Quality;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRoseTests
{
    [TestFixture]
    public class LegendaryQualityStrategyTests
    {
        [Test]
        public void UpdateQuality_ShouldNotChangeQuality()
        {
            // Arrange
            var product = new Product("Legendary Product", 10, 80, 100m, new List<IPriceStrategy>(), new LegendaryQualityStrategy());
            var strategy = new LegendaryQualityStrategy();

            // Act
            strategy.UpdateQuality(product);

            // Assert
            Assert.That(product.Quality, Is.EqualTo(80));
        }
    }
}
