using supermarketapp.DTO;
using supermarketapp.Interfaces;
using supermarketapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace supermarketapp.Services
{
    public class CashRegister : ICashRegister
    {
        public decimal Total(Basket basket)
        {
            decimal total = 0;
            if (basket != null && basket.Products != null)
            {
                List<ProductGroup> productGroups = new List<ProductGroup>();
                productGroups = GroupProductsByCode(basket);
                productGroups.ForEach(productGroup =>
                {
                    total += CalculatePrice(productGroup);
                });
            }
            return total;
        }
        private decimal CalculatePrice(ProductGroup productGroup)
        {
            decimal price;
            if (productGroup.Product.Discounts != null && productGroup.Product.Discounts.Any())
            {
                Discount activeDiscount = productGroup.Product.Discounts.FirstOrDefault(discount => discount.StartDate <= DateTime.Today && (discount.EndDate >= DateTime.Today || discount.EndDate == null));
                if (activeDiscount != null)
                {
                    if (productGroup.Total >= activeDiscount.ItemCount)
                    {
                        price = (int)(productGroup.Total / activeDiscount.ItemCount) * activeDiscount.TotalPrice
                            + (productGroup.Total % activeDiscount.ItemCount) * productGroup.Product.Price;
                    }
                    else
                    {
                        price = (productGroup.Total % activeDiscount.ItemCount) * productGroup.Product.Price;
                    }
                }
                else
                {
                    price = productGroup.Total * productGroup.Product.Price;
                }
            }
            else
            {
                price = productGroup.Total * productGroup.Product.Price;
            }
            return price;
        }
        private List<ProductGroup> GroupProductsByCode(Basket basket)
        {
            List<ProductGroup> productGroups = new List<ProductGroup>();
            foreach (var productGroup in basket.Products.GroupBy(product => product.Code))
            {
                productGroups.Add(new ProductGroup()
                {
                    Total = productGroup.Count(),
                    Product = productGroup.First()
                });
            }
            return productGroups;
        }
    }
}
