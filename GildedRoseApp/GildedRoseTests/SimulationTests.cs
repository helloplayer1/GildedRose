using GildedRoseApp.Entities;
using GildedRoseApp.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRoseTests
{
    [TestFixture]
    public class SimulationTests
    {
        [Test]
        public void NextDay_ShouldDecreaseSellInDaysAndUpdateQuality()
        {
            // Arrange
            var mockQualityStrategy = new Mock<IQualityStrategy>();
            var product1 = new Product("Product1", 10, 20, 100m, new List<IPriceStrategy>(), mockQualityStrategy.Object);
            var product2 = new Product("Product2", 5, 10, 200m, new List<IPriceStrategy>(), mockQualityStrategy.Object);
            var products = new List<Product> { product1, product2 };
            var cart = new Cart(products, new List<ICartDiscountStrategy>());
            var currencies = new List<Currency> { new Currency("USD", 1.0m) };
            var simulation = new Simulation(products, cart, currencies);

            // Act
            simulation.NextDay();

            // Assert
            Assert.That(product1.SellInDays, Is.EqualTo(9));
            Assert.That(product2.SellInDays, Is.EqualTo(4));
            mockQualityStrategy.Verify(qs => qs.UpdateQuality(It.IsAny<Product>()), Times.Exactly(2));
        }

        [Test]
        public void NextDay_ShouldHandleEmptyProductList()
        {
            // Arrange
            var cart = new Cart(new List<Product>(), new List<ICartDiscountStrategy>());
            var currencies = new List<Currency> { new Currency("USD", 1.0m) };
            var simulation = new Simulation(new List<Product>(), cart, currencies);

            // Act & Assert
            Assert.DoesNotThrow(() => simulation.NextDay());
        }
    }
}


