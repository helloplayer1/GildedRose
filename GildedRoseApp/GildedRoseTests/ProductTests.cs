using GildedRoseApp.Entities;
using GildedRoseApp.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRoseTests
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void GetPrice_ShouldReturnCorrectPrice()
        {
            // Arrange
            var mockPriceStrategy = new Mock<IPriceStrategy>();
            mockPriceStrategy.Setup(ps => ps.CalculatePrice(It.IsAny<Product>(), It.IsAny<decimal>()))
                             .Returns((Product product, decimal price) => price * 1.1m);
            var priceStrategies = new List<IPriceStrategy> { mockPriceStrategy.Object };
            var product = new Product("Test Product", 10, 20, 100m, priceStrategies, Mock.Of<IQualityStrategy>());
            var currency = new Currency("USD", 1.2m);

            // Act
            var price = product.GetPrice(currency);

            // Assert
            Assert.That(price, Is.EqualTo(132m));
        }

        [Test]
        public void UpdateQuality_ShouldUpdateQualityCorrectly()
        {
            // Arrange
            var mockQualityStrategy = new Mock<IQualityStrategy>();
            mockQualityStrategy.Setup(qs => qs.UpdateQuality(It.IsAny<Product>())).Callback<Product>(p => p.Quality -= 1);
            var product = new Product("Test Product", 10, 20, 100m, new List<IPriceStrategy>(), mockQualityStrategy.Object);

            // Act
            product.UpdateQuality();

            // Assert
            Assert.That(product.Quality, Is.EqualTo(19));
        }

        [Test]
        public void UpdateQuality_ShouldNotSetNegativeQuality()
        {
            // Arrange
            var mockQualityStrategy = new Mock<IQualityStrategy>();
            mockQualityStrategy.Setup(qs => qs.UpdateQuality(It.IsAny<Product>())).Callback<Product>(p => p.Quality -= 30);
            var product = new Product("Test Product", 10, 20, 100m, new List<IPriceStrategy>(), mockQualityStrategy.Object);

            // Act
            product.UpdateQuality();

            // Assert
            Assert.That(product.Quality, Is.EqualTo(0));
        }

        [Test]
        public void ToString_ShouldReturnCorrectString()
        {
            // Arrange
            var product = new Product("Test Product", 10, 20, 100m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>());
            var expectedString = "Name: Test Product, SellInDays: 10, Quality: 20, Price: 100,00";

            // Act
            var result = product.ToString();

            // Assert
            Assert.That(result, Is.EqualTo(expectedString));
        }

        [Test]
        public void GetPrice_ShouldReturnBasePrice_WhenNoPriceStrategy()
        {
            // Arrange
            var product = new Product("Test Product", 10, 20, 100m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>());
            var currency = new Currency("USD", 1.0m);

            // Act
            var price = product.GetPrice(currency);

            // Assert
            Assert.That(price, Is.EqualTo(100m));
        }
    }
}
