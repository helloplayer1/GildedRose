using GildedRoseApp.Entities;
using System.ComponentModel;

namespace GildedRoseApp.Interfaces
{
    public interface IQualityStrategy
    {
        public void UpdateQuality(Product product);
    }
}