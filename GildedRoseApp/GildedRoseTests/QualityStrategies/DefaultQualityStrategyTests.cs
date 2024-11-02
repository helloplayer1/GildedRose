using GildedRoseApp.Entities;
using GildedRoseApp.Interfaces;
using GildedRoseApp.Strategies.Quality;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRoseTests
{
    [TestFixture]
    public class DefaultQualityStrategyTests
    {
        [Test]
        public void UpdateQuality_ShouldDecreaseQualityByOne()
        {
            // Arrange
            var product = new Product("Default Product", 10, 20, 100m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>());
            var strategy = new DefaultQualityStrategy();

            // Act
            strategy.UpdateQuality(product);

            // Assert
            Assert.That(product.Quality, Is.EqualTo(19));
        }

        [Test]
        public void UpdateQuality_ShouldDecreaseQualityByTwo_WhenSellInDaysLessThanZero()
        {
            // Arrange
            var product = new Product("Default Product", -1, 20, 100m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>());
            var strategy = new DefaultQualityStrategy();

            // Act
            strategy.UpdateQuality(product);

            // Assert
            Assert.That(product.Quality, Is.EqualTo(18));
        }
    }
}



