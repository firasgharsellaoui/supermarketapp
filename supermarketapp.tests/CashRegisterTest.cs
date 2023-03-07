using Katas.Supermarket.Promotions;
using supermarketapp.Enum;
using supermarketapp.Interfaces;
using supermarketapp.Models;
using supermarketapp.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace supermarketapp.tests
{
    public class SuperMarketTests
    {
        private const int Beans = 1;
        private const int Avocados = 2;
        private const int Soda = 3;

        private static readonly List<Product> Products = new List<Product>
        {
            new Product(Guid.NewGuid(), "Can of Beans", 1 , 0.65M , WeightUnit.Unit),
            new Product(Guid.NewGuid(), "Avocados", 2 , 1.25M , WeightUnit.Kilo),
            new Product(Guid.NewGuid(), "Can of Soda", 3 , 2.05M, WeightUnit.Unit)
        };
        private static readonly BuyXForY BuyThreeKiloOfBeansForThreePromotion = new BuyXForY(3, 3);
        private static readonly BuyXGetYFree BuyOneSodaGetOneFreePromotion = new BuyXGetYFree(1, 1);


        #region Test Cart 
        [Fact]
        public void ScanEmptyCart()
        {
            // Arrange 
            Cart emptyCart = new Cart();
            Supermarket _supermarket = new(Products, new Dictionary<int, IPromotion>());
            
            // Act
            decimal total = _supermarket.Checkout(emptyCart).TotalAfterDiscount;

            //Assert
            Assert.Equal(0, total);

        }
        [Fact]
        public void ScanCartWithOneItemEach()
        {
            // Arrange 
            Cart cart = new Cart();
            cart.Items = new List<CartItem>
                    {
                        new CartItem(Beans, 1,WeightUnit.Unit),
                        new CartItem(Avocados, 1,WeightUnit.Kilo),
                        new CartItem(Soda, 1,WeightUnit.Unit)
                    };
            Supermarket _supermarket = new Supermarket(Products, new Dictionary<int, IPromotion>());

            // Act
            decimal total = _supermarket.Checkout(cart).TotalAfterDiscount;

            //Assert
            Assert.Equal(3.95M, total);

        }

        [Fact]
        public void ScanCartWithMultipleItems()
        {
            // Arrange 
            Cart cart = new Cart();
            cart.Items = new List<CartItem>
                    {
                        new CartItem(Beans, 3,WeightUnit.Unit),
                        new CartItem(Avocados, 2,WeightUnit.Kilo),
                        new CartItem(Soda, 2,WeightUnit.Unit)
                    };
            Supermarket _supermarket = new Supermarket(Products, new Dictionary<int, IPromotion>());

            // Act
            decimal total = _supermarket.Checkout(cart).TotalAfterDiscount;

            //Assert
            Assert.Equal(8.55M, total);

        }
        #endregion

        #region Test Promotion 
        
        [Fact]
        public void ScanCartBuyThreeKiloBeansForThree()
        {
            // Arrange 
            Cart cart = new Cart();
            cart.Items = new List<CartItem>
                    {
                        new CartItem(Beans, 3,WeightUnit.Unit)
                    };
            Dictionary<int, IPromotion> BuyThreeKiloOfBeansForThree = new Dictionary<int, IPromotion>
            {
                { Beans, BuyThreeKiloOfBeansForThreePromotion}
            };
            Supermarket _supermarket = new Supermarket(Products, BuyThreeKiloOfBeansForThree);

            // Act
            decimal total = _supermarket.Checkout(cart).TotalAfterDiscount;

            //Assert
            Assert.Equal(3, total);

        }

        [Fact]
        public void ScanCartBuyOneSodaGetOneFree()
        {
            // Arrange 
            Cart cart = new Cart();
            cart.Items = new List<CartItem>
                    {
                        new CartItem(Soda, 2,WeightUnit.Unit)
                    };
            Dictionary<int, IPromotion> BuyOneSodaGetOneFree = new Dictionary<int, IPromotion>
            {
                {Soda, BuyOneSodaGetOneFreePromotion},
            };
            Supermarket _supermarket = new Supermarket(Products, BuyOneSodaGetOneFree);

            // Act
            decimal total = _supermarket.Checkout(cart).TotalAfterDiscount;

            //Assert
            Assert.Equal(2.05M, total);

        }

        [Fact]
        public void ScanCartMultiPromotions()
        {
            // Arrange 
            Cart cart = new Cart();
            cart.Items = new List<CartItem>
            {
                new CartItem(Beans, 3,WeightUnit.Unit),
                new CartItem(Soda, 2,WeightUnit.Unit)
            };
            Dictionary<int, IPromotion> promotions = new Dictionary<int, IPromotion>
            {
                {   Soda, BuyOneSodaGetOneFreePromotion },
                {   Beans, BuyThreeKiloOfBeansForThreePromotion }

            };
            Supermarket _supermarket = new Supermarket(Products, promotions);

            // Act
            decimal total = _supermarket.Checkout(cart).TotalAfterDiscount;

            //Assert
            Assert.Equal(5.05M, total);

        }

        [Fact]
        public void ScanCartMultiPromotionsWithOneItemWithoutPromotion()
        {
            // Arrange 
            Cart cart = new Cart();
            cart.Items = new List<CartItem>
            {
                new CartItem(Beans, 3,WeightUnit.Unit),
                new CartItem(Soda, 2,WeightUnit.Unit),
                new CartItem(Avocados, 1,WeightUnit.Unit)
            };
            Dictionary<int, IPromotion> promotions = new Dictionary<int, IPromotion>
            {
                {   Soda, BuyOneSodaGetOneFreePromotion },
                {   Beans, BuyThreeKiloOfBeansForThreePromotion }

            };
            Supermarket _supermarket = new Supermarket(Products, promotions);

            // Act
            decimal total = _supermarket.Checkout(cart).TotalAfterDiscount;

            //Assert
            Assert.Equal(6.30M, total);

        }

        [Fact]
        public void ScanCartOneItemApplyPromotionTwice()
        {
            // Arrange 
            Cart cart = new Cart();
            cart.Items = new List<CartItem>
            {
                new CartItem(Beans, 6,WeightUnit.Unit)
            };
            Dictionary<int, IPromotion> promotions = new Dictionary<int, IPromotion>
            {
                {   Beans, BuyThreeKiloOfBeansForThreePromotion }

            };
            Supermarket _supermarket = new Supermarket(Products, promotions);

            // Act
            decimal total = _supermarket.Checkout(cart).TotalAfterDiscount;

            //Assert
            Assert.Equal(6M, total);

        }


        [Fact]
        public void ScanCartAvocadosWeightConversion()
        {
            // Arrange 
            Cart cart = new Cart();
            cart.Items = new List<CartItem>
            {
                new CartItem(Avocados, 2.205M,WeightUnit.Pound)
            };
            Dictionary<int, IPromotion> promotions = new Dictionary<int, IPromotion>
            {
            };
            Supermarket _supermarket = new Supermarket(Products, promotions);

            // Act
            decimal total = _supermarket.Checkout(cart).TotalAfterDiscount;

            //Assert
            Assert.Equal(1.25M, Math.Round(total,2));

        }
        #endregion
    }
}
