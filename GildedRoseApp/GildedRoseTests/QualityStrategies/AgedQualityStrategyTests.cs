using GildedRoseApp.Entities;
using GildedRoseApp.Interfaces;
using GildedRoseApp.Strategies.Quality;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRoseTests
{
    [TestFixture]
    public class AgedQualityStrategyTests
    {
        [Test]
        public void UpdateQuality_ShouldIncreaseQualityByOne()
        {
            // Arrange
            var product = new Product("Aged Product", 10, 20, 100m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>());
            var strategy = new AgedQualityStrategy();

            // Act
            strategy.UpdateQuality(product);

            // Assert
            Assert.That(product.Quality, Is.EqualTo(21));
        }

        [Test]
        public void UpdateQuality_ShouldNotIncreaseQualityAboveMax()
        {
            // Arrange
            var product = new Product("Aged Product", 10, 50, 100m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>());
            var strategy = new AgedQualityStrategy();

            // Act
            strategy.UpdateQuality(product);

            // Assert
            Assert.That(product.Quality, Is.EqualTo(50));
        }
    }
}


