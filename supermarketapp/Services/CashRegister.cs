using supermarketapp.DTO;
using supermarketapp.Enum;
using supermarketapp.Interfaces;
using supermarketapp.Models;
using supermarketapp.UnitConverters;
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
            if (basket != null )
            {
                List<ProductGroup> productGroups = new List<ProductGroup>();
                productGroups = GroupProductsByCode(basket);
                productGroups.ForEach(productGroup =>
                {
                    Discount activeDiscount = new Discount();
                    if (productGroup.UnitProduct != null  && productGroup.UnitProduct.Discounts.Any())
                    {
                        activeDiscount = productGroup.UnitProduct.Discounts.FirstOrDefault(discount => discount.StartDate <= DateTime.Today && (discount.EndDate >= DateTime.Today || discount.EndDate == null));
                    }
                    if (productGroup.WeightedProduct != null && productGroup.WeightedProduct.Discounts.Any())
                    {
                        activeDiscount = productGroup.WeightedProduct.Discounts.FirstOrDefault(discount => discount.StartDate <= DateTime.Today && (discount.EndDate >= DateTime.Today || discount.EndDate == null));
                    }
                    total += ComputePrice(productGroup,activeDiscount);
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
            return productGroup.Total <= productGroup.UnitProduct.RemainingItemsCount ;
        }

        /// <summary>
        /// Compute product group price
        /// </summary>
        /// <param name="productGroup"></param>
        /// <returns></returns>
        private decimal ComputePrice(ProductGroup productGroup, Discount activeDiscount)
        {
            decimal price = 0;
            if (productGroup.UnitProduct != null)
            {
                price = ComputeUnitProductPrice(productGroup, activeDiscount);
            }
            if (productGroup.WeightedProduct != null)
            {
                price = ComputeWeightedProductPrice(productGroup, activeDiscount);

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
            foreach (var productGroup in basket.UnitProducts.GroupBy(product => product.Code))
            {
                productGroups.Add(new ProductGroup()
                {
                    Total = productGroup.Count(),
                    UnitProduct = productGroup.First()
                });
            }
            foreach (var productGroup in basket.WeightedProducts.GroupBy(product => product.Code))
            {
                productGroups.Add(new ProductGroup()
                {
                    Total = productGroup.Sum(weightedProduct => WeightUnitConverter.Convert(weightedProduct.Unit, WeightUnit.Kilo, weightedProduct.Weight)),
                    WeightedProduct = productGroup.First()
                });
            }
            return productGroups;
        }

        /// <summary>
        /// Compute unit product price
        /// </summary>
        /// <param name="productGroup"></param>
        /// <param name="activeDiscount"></param>
        /// <returns></returns>
        private decimal ComputeUnitProductPrice(ProductGroup productGroup, Discount activeDiscount)
        {
            decimal price;
            if (productGroup.UnitProduct.Discounts != null && productGroup.UnitProduct.Discounts.Any())
            {
                if (activeDiscount != null)
                {
                    if (productGroup.Total >= activeDiscount.ItemCount)
                    {
                        price = (int)(productGroup.Total / activeDiscount.ItemCount) * activeDiscount.TotalPrice
                            + (productGroup.Total % activeDiscount.ItemCount) * productGroup.UnitProduct.Price;
                    }
                    else
                    {
                        price = (productGroup.Total % activeDiscount.ItemCount) * productGroup.UnitProduct.Price;
                    }
                }
                else
                {
                    price = productGroup.Total * productGroup.UnitProduct.Price;
                }
            }
            else
            {
                price = productGroup.Total * productGroup.UnitProduct.Price;
            }
            return price;
        }
        
        /// <summary>
        /// Compute weighted product price
        /// </summary>
        /// <param name="productGroup"></param>
        /// <param name="activeDiscount"></param>
        /// <returns></returns>
        private decimal ComputeWeightedProductPrice(ProductGroup productGroup, Discount activeDiscount)
        {
            decimal price;
            if (productGroup.WeightedProduct.Discounts != null && productGroup.WeightedProduct.Discounts.Any())
            {
                if (activeDiscount != null)
                {
                    if (productGroup.Total >= activeDiscount.ItemCount)
                    {
                        price = (int)(productGroup.Total / activeDiscount.ItemCount) * activeDiscount.TotalPrice
                            + (productGroup.Total % activeDiscount.ItemCount) * productGroup.WeightedProduct.PricePerKilo;
                    }
                    else
                    {
                        price = (productGroup.Total % activeDiscount.ItemCount) * productGroup.WeightedProduct.PricePerKilo;
                    }
                }
                else
                {
                    price = productGroup.Total * productGroup.WeightedProduct.PricePerKilo;
                }
            }
            else
            {
                price = productGroup.Total * productGroup.WeightedProduct.PricePerKilo;
            }
            return price;
        }

    }
}
