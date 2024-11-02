using GildedRoseApp.Entities;
using GildedRoseApp.Strategies.Price;
using NUnit.Framework;
using System;

namespace GildedRoseTests.PriceStrategies
{
    [TestFixture]
    public class PercentagePriceDiscountStrategyTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentException_WhenDiscountPercentageIsLessThanZero()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => new PercentageDiscountPriceStrategy(-0.1m));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentException_WhenDiscountPercentageIsGreaterThanOne()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => new PercentageDiscountPriceStrategy(1.1m));
        }

        [Test]
        public void CalculatePrice_ShouldApplyDiscountCorrectly()
        {
            // Arrange
            var product = new Product("Discounted Product", 10, 20, 100m, null, null);
            var strategy = new PercentageDiscountPriceStrategy(0.2m);
            decimal interimPrice = 100m;

            // Act
            var result = strategy.CalculatePrice(product, interimPrice);

            // Assert
            Assert.That(result, Is.EqualTo(80m));
        }

        [Test]
        public void CalculatePrice_ShouldReturnSamePrice_WhenDiscountPercentageIsZero()
        {
            // Arrange
            var product = new Product("No Discount Product", 10, 20, 100m, null, null);
            var strategy = new PercentageDiscountPriceStrategy(0m);
            decimal interimPrice = 100m;

            // Act
            var result = strategy.CalculatePrice(product, interimPrice);

            // Assert
            Assert.That(result, Is.EqualTo(100m));
        }

        [Test]
        public void CalculatePrice_ShouldReturnZero_WhenDiscountPercentageIsOne()
        {
            // Arrange
            var product = new Product("Full Discount Product", 10, 20, 100m, null, null);
            var strategy = new PercentageDiscountPriceStrategy(1m);
            decimal interimPrice = 100m;

            // Act
            var result = strategy.CalculatePrice(product, interimPrice);

            // Assert
            Assert.That(result, Is.EqualTo(0m));
        }
    }
}


