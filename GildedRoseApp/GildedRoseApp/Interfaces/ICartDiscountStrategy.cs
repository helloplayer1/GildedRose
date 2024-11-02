using GildedRoseApp.Entities;

namespace GildedRoseApp.Interfaces
{
    public interface ICartDiscountStrategy
    {
        public decimal CalculateDiscountedPrice(Cart cart, decimal interimPrice);
    }
}