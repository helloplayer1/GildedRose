using GildedRoseApp.Entities;

namespace GildedRoseApp.Interfaces
{
    public interface IPriceStrategy
    {
        public decimal CalculatePrice(Product product, decimal interimPrice);
    }
}