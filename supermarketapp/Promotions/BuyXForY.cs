using supermarketapp.Interfaces;
using supermarketapp.Models;
using System;

namespace Katas.Supermarket.Promotions
{
    /// <summary>
    /// Buy X amount of product and get for Y. E.g. 2 Avocados for $3.00.
    /// </summary>
    public class BuyXForY : IPromotion
    {
        private readonly decimal _x;
        private readonly decimal _y;

        public BuyXForY(decimal x, decimal y)
        {
            _x = x;
            _y = y;
        }

        public decimal CalculateDiscount(decimal productPrice, decimal quantity)
        {
            return _x == 0
                ? 0
                : (int) (quantity / _x) * (productPrice * _x - _y);
        }
    }
}