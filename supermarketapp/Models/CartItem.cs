using supermarketapp.Enum;
using System;

namespace supermarketapp.Models
{
    public class CartItem
    {
        public int ProductCode { get; }
        public decimal Quantity { get; }
        public WeightUnit WeightUnit { get; set; }

        public CartItem(int productCode, decimal quantity, WeightUnit weightUnit)
        {
            ProductCode = productCode;
            Quantity = quantity;
            WeightUnit = weightUnit;
        }

    }
}
