using GildedRoseApp.Entities;
using GildedRoseApp.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRoseTests
{
    [TestFixture]
    public class CartTests
    {
        [Test]
        public void GetTotalPrice_ShouldReturnCorrectTotalPriceWithoutDiscounts()
        {
            // Arrange
            var product1 = new Product("Product1", 10, 20, 100m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>());
            var product2 = new Product("Product2", 5, 10, 200m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>());
            var products = new List<Product> { product1, product2 };
            var cart = new Cart(products, new List<ICartDiscountStrategy>());
            var currency = new Currency("USD", 1.0m);

            // Act
            var totalPrice = cart.GetTotalPrice(currency);

            // Assert
            Assert.That(totalPrice, Is.EqualTo(300m));
        }

        [Test]
        public void GetTotalPrice_ShouldApplyDiscountStrategies()
        {
            // Arrange
            var product1 = new Product("Product1", 10, 20, 100m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>());
            var product2 = new Product("Product2", 5, 10, 200m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>());
            var products = new List<Product> { product1, product2 };
            var mockDiscountStrategy = new Mock<ICartDiscountStrategy>();
            var discountStrategies = new List<ICartDiscountStrategy> { mockDiscountStrategy.Object };
            var cart = new Cart(products, discountStrategies);
            var currency = new Currency("USD", 1.0m);

            mockDiscountStrategy.Setup(ds => ds.CalculateDiscountedPrice(cart, 300m)).Returns(270m);

            // Act
            var totalPrice = cart.GetTotalPrice(currency);

            // Assert
            Assert.That(totalPrice, Is.EqualTo(270m));
        }

        [Test]
        public void GetTotalPrice_ShouldReturnZero_WhenCartIsEmpty()
        {
            // Arrange
            var cart = new Cart(new List<Product>(), new List<ICartDiscountStrategy>());
            var currency = new Currency("USD", 1.0m);

            // Act
            var totalPrice = cart.GetTotalPrice(currency);

            // Assert
            Assert.That(totalPrice, Is.EqualTo(0m));
        }

        [Test]
        public void GetTotalPrice_ShouldHandleNullDiscountStrategies()
        {
            // Arrange
            var product1 = new Product("Product1", 10, 20, 100m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>());
            var product2 = new Product("Product2", 5, 10, 200m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>());
            var products = new List<Product> { product1, product2 };
            var cart = new Cart(products, null);
            var currency = new Currency("USD", 1.0m);

            // Act
            var totalPrice = cart.GetTotalPrice(currency);

            // Assert
            Assert.That(totalPrice, Is.EqualTo(300m));
        }

        [Test]
        public void GetTotalPrice_ShouldHandleEmptyDiscountStrategies()
        {
            // Arrange
            var product1 = new Product("Product1", 10, 20, 100m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>());
            var product2 = new Product("Product2", 5, 10, 200m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>());
            var products = new List<Product> { product1, product2 };
            var cart = new Cart(products, new List<ICartDiscountStrategy>());
            var currency = new Currency("USD", 1.0m);

            // Act
            var totalPrice = cart.GetTotalPrice(currency);

            // Assert
            Assert.That(totalPrice, Is.EqualTo(300m));
        }
    }
}

