using GildedRoseApp.Entities;
using GildedRoseApp.Interfaces;
using GildedRoseApp.Strategies.Quality;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRoseTests
{
    [TestFixture]
    public class TicketQualityStrategyTests
    {
        [Test]
        public void UpdateQuality_ShouldSetQualityToZero_WhenSellInDaysIsZeroOrLess()
        {
            // Arrange
            var product = new Product("Ticket", 0, 20, 100m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>());
            var strategy = new TicketQualityStrategy();

            // Act
            strategy.UpdateQuality(product);

            // Assert
            Assert.That(product.Quality, Is.EqualTo(0));
        }

        [Test]
        public void UpdateQuality_ShouldIncreaseQualityByOne_WhenSellInDaysIsMoreThanTen()
        {
            // Arrange
            var product = new Product("Ticket", 15, 20, 100m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>());
            var strategy = new TicketQualityStrategy();

            // Act
            strategy.UpdateQuality(product);

            // Assert
            Assert.That(product.Quality, Is.EqualTo(21));
        }

        [Test]
        public void UpdateQuality_ShouldIncreaseQualityByTwo_WhenSellInDaysIsTenOrLess()
        {
            // Arrange
            var product = new Product("Ticket", 10, 20, 100m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>());
            var strategy = new TicketQualityStrategy();

            // Act
            strategy.UpdateQuality(product);

            // Assert
            Assert.That(product.Quality, Is.EqualTo(22));
        }

        [Test]
        public void UpdateQuality_ShouldIncreaseQualityByThree_WhenSellInDaysIsFiveOrLess()
        {
            // Arrange
            var product = new Product("Ticket", 5, 20, 100m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>());
            var strategy = new TicketQualityStrategy();

            // Act
            strategy.UpdateQuality(product);

            // Assert
            Assert.That(product.Quality, Is.EqualTo(23));
        }

        [Test]
        public void UpdateQuality_ShouldNotIncreaseQualityAboveMax()
        {
            // Arrange
            var product = new Product("Ticket", 5, 49, 100m, new List<IPriceStrategy>(), Mock.Of<IQualityStrategy>());
            var strategy = new TicketQualityStrategy();

            // Act
            strategy.UpdateQuality(product);

            // Assert
            Assert.That(product.Quality, Is.EqualTo(50));
        }
    }
}

