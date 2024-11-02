using GildedRoseApp.Entities;
using GildedRoseApp.Interfaces;
using GildedRoseApp.Strategies.Price;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRoseTests.PriceStrategies
{
    [TestFixture]
    public class DefaultPriceStrategyTests
    {
        [Test]
        public void CalculatePrice_ShouldReturnCorrectPrice_WhenQualityIsAbove25()
        {
            // Arrange
            var product = new Product("Regular Product", 10, 30, 100m, new List<IPriceStrategy>(), null);
            var strategy = new DefaultPriceStrategy();
            decimal interimPrice = 100m;

            // Act
            var result = strategy.CalculatePrice(product, interimPrice);

            // Assert
            Assert.That(result, Is.EqualTo(105m));
        }

        [Test]
        public void CalculatePrice_ShouldReturnCorrectPrice_WhenQualityIsBelow25()
        {
            // Arrange
            var product = new Product("Regular Product", 10, 20, 100m, new List<IPriceStrategy>(), null);
            var strategy = new DefaultPriceStrategy();
            decimal interimPrice = 100m;

            // Act
            var result = strategy.CalculatePrice(product, interimPrice);

            // Assert
            Assert.That(result, Is.EqualTo(95m));
        }

        [Test]
        public void CalculatePrice_ShouldReturnCorrectPrice_WhenQualityIsExactly25()
        {
            // Arrange
            var product = new Product("Regular Product", 10, 25, 100m, new List<IPriceStrategy>(), null);
            var strategy = new DefaultPriceStrategy();
            decimal interimPrice = 100m;

            // Act
            var result = strategy.CalculatePrice(product, interimPrice);

            // Assert
            Assert.That(result, Is.EqualTo(100m));
        }
    }
}

