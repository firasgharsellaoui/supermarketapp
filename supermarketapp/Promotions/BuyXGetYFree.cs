using supermarketapp.Interfaces;
using supermarketapp.Models;
using System;

namespace Katas.Supermarket.Promotions
{
    /// <summary>
    /// Buy X amount of product and get for Y items for free. E.g. 2 Avocados get 1 free.
    /// </summary>
    public class BuyXGetYFree : IPromotion
    {
        private readonly decimal _x;
        private readonly decimal _y;

        public BuyXGetYFree(decimal x, decimal y)
        {
            _x = x;
            _y = y;
        }

        public decimal CalculateDiscount(decimal productPrice, decimal quantity)
        {
            return _x == 0
                ? 0
                : (quantity / (_x + 1)) * (productPrice * _y);
        }
    }
}