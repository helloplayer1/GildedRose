using GildedRoseApp.Entities;
using GildedRoseApp.Interfaces;
using GildedRoseApp.Strategies.CartDiscount;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRoseTests
{
    [TestFixture]
    public class BulkDiscountStrategyTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentException_WhenDiscountPercentageIsLessThanZero()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => new BulkCartDiscountStrategy(-0.1m, 10));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentException_WhenDiscountPercentageIsGreaterThanOne()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => new BulkCartDiscountStrategy(1.1m, 10));
        }

        [Test]
        public void CalculateDiscountedPrice_ShouldReturnSamePrice_WhenCartProductsCountIsLessThanPieceAmount()
        {
            // Arrange
            var cart = new Cart(new List<Product>
            {
                new Product("Product 1", 10, 20, 100m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>()),
                new Product("Product 2", 10, 20, 100m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>())
            }, null);
            var strategy = new BulkCartDiscountStrategy(0.2m, 3);
            decimal interimPrice = 200m;

            // Act
            var result = strategy.CalculateDiscountedPrice(cart, interimPrice);

            // Assert
            Assert.That(result, Is.EqualTo(200m));
        }

        [Test]
        public void CalculateDiscountedPrice_ShouldApplyDiscount_WhenCartProductsCountIsEqualToPieceAmount()
        {
            // Arrange
            var cart = new Cart(new List<Product>
            {
                new Product("Product 1", 10, 20, 100m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>()),
                new Product("Product 2", 10, 20, 100m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>()),
                new Product("Product 3", 10, 20, 100m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>())
            },null);
            var strategy = new BulkCartDiscountStrategy(0.2m, 3);
            decimal interimPrice = 300m;

            // Act
            var result = strategy.CalculateDiscountedPrice(cart, interimPrice);

            // Assert
            Assert.That(result, Is.EqualTo(240m));
        }

        [Test]
        public void CalculateDiscountedPrice_ShouldApplyDiscount_WhenCartProductsCountIsGreaterThanPieceAmount()
        {
            // Arrange
            var cart = new Cart(new List<Product>
            {
                new Product("Product 1", 10, 20, 100m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>()),
                new Product("Product 2", 10, 20, 100m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>()),
                new Product("Product 3", 10, 20, 100m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>()),
                new Product("Product 4", 10, 20, 100m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>())
            }, null);
            var strategy = new BulkCartDiscountStrategy(0.2m, 3);
            decimal interimPrice = 400m;

            // Act
            var result = strategy.CalculateDiscountedPrice(cart, interimPrice);

            // Assert
            Assert.That(result, Is.EqualTo(320m));
        }
    }
}


