using supermarketapp.Interfaces;
using supermarketapp.Models;
using supermarketapp.UnitConverters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace supermarketapp.Services
{
    public class Supermarket
    {
        public IList<Product> Products { get; set; }
        public IDictionary<int, IPromotion> Promotions { get; set; }

        public Supermarket(IList<Product> products, IDictionary<int, IPromotion> promotions)
        {
            Products = products;
            Promotions = promotions;
        }

        public CheckoutSummary Checkout(Cart cart)
        {
            var total = CalculateTotal(cart);
            var discount = CalculateTotalDiscount(cart);

            return new CheckoutSummary(total, discount);
        }

        #region private helpers

        private decimal CalculateTotal(Cart cart)
        {
            return cart.Items
                .Join(Products, i => i.ProductCode, p => p.Code, (item, product) => item.Quantity * CalculatePriceForDifferentWeightUnit(item, product))
                .Sum();
        }

        private decimal CalculateTotalDiscount(Cart cart)
        {
            return cart.Items
                .Join(Products, i => i.ProductCode, p => p.Code, (item, product) => CalculateItemDiscount(product, item))
                .Sum();
        }

        private decimal CalculateItemDiscount(Product product, CartItem item)
        {
            return Promotions.ContainsKey(product.Code) ? Promotions[product.Code].CalculateDiscount(CalculatePriceForDifferentWeightUnit(item,product), item.Quantity)
                : 0;
        }
        private static decimal CalculatePriceForDifferentWeightUnit(CartItem item,Product product)
        {
            return WeightUnitConverter.Convert(item.WeightUnit, product.WeightUnit, product.Price);
        }
        #endregion
    }
}
