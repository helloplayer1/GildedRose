using GildedRoseApp.Entities;
using GildedRoseApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseApp.Strategies.CartDiscount
{
    public class BulkDiscountStrategy : ICartDiscountStrategy
    {
        public decimal DiscountPercentage { get; init; }
        public int PieceAmount { get; init; }
        public BulkDiscountStrategy(decimal discountPercentage, int pieceAmount)
        {
            DiscountPercentage = discountPercentage;
            PieceAmount = pieceAmount;

            if (DiscountPercentage < 0 || DiscountPercentage > 1)
            {
                throw new ArgumentException("Discount percentage must be between 0 and 1");
            }
        }
        public decimal CalculateDiscountedPrice(Cart cart, decimal interimPrice)
        {
            if (cart.Products.Count < PieceAmount)
            {
                return interimPrice;
            }
            
            return interimPrice * (1 - DiscountPercentage);
        }
    }
}
