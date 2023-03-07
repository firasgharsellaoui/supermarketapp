using supermarketapp.Models;

namespace supermarketapp.Interfaces
{
    public interface IPromotion
    {
        decimal CalculateDiscount(decimal productPrice , decimal quantity);
    }
}
