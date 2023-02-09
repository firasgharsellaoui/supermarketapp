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
        /// <summary>
        /// Compute total price
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Check if the requested products are in stock
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        public bool AreProductsInStock(Basket basket)
        {
            bool isInStock = true;
            List<ProductGroup> productGroups = new List<ProductGroup>();
            productGroups = GroupProductsByCode(basket);
            productGroups.ForEach(productGroup =>
            {
                if (!IsProductGroupInStock(productGroup))
                {
                    isInStock = false;
                }
            });
            return isInStock;
        }


        /// <summary>
        /// Check if a product group in stock
        /// </summary>
        /// <param name="productGroup"></param>
        /// <returns></returns>
        private bool IsProductGroupInStock(ProductGroup productGroup)
        {
            return productGroup.Total <= productGroup.Product.RemainingItemsCount ;
        }

        /// <summary>
        /// Compute product group price
        /// </summary>
        /// <param name="productGroup"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Transform basket to List of Product Group
        /// This method is used to check for possible discount
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
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
