using GildedRoseApp.Entities;
using GildedRoseApp.Interfaces;
using GildedRoseApp.Strategies.Quality;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRoseTests
{
    [TestFixture]
    public class ConjuredQualityStrategyTests
    {
        [Test]
        public void UpdateQuality_ShouldDecreaseQualityByTwo()
        {
            // Arrange
            var product = new Product("Conjured Product", 10, 20, 100m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>());
            var strategy = new ConjuredQualityStrategy();

            // Act
            strategy.UpdateQuality(product);

            // Assert
            Assert.That(product.Quality, Is.EqualTo(18));
        }

        [Test]
        public void UpdateQuality_ShouldDecreaseQualityByFour_WhenSellInDaysLessThanZero()
        {
            // Arrange
            var product = new Product("Conjured Product", -1, 20, 100m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>());
            var strategy = new ConjuredQualityStrategy();

            // Act
            strategy.UpdateQuality(product);

            // Assert
            Assert.That(product.Quality, Is.EqualTo(16));
        }
    }
}



