namespace GildedRoseApp.Interfaces
{
    public interface IPriceStrategy
    {
        public decimal CalculatePrice(decimal price);
    }
}