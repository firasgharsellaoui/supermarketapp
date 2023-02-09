using supermarketapp.Interfaces;
using supermarketapp.Models;
using supermarketapp.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace supermarketapp.tests
{
    public class CashRegisterTest
    {
        private readonly ICashRegister _register;
        public CashRegisterTest()
        {
            // TODO : Implement dependency injection
            _register = new CashRegister();
        }

        #region Test basket 
        [Fact]
        public void ScanEmptyBasket()
        {
            // Arrange 
            Basket emptyBasket = new Basket();

            // Act
            decimal total = _register.Total(emptyBasket);

            //Assert
            Assert.Equal(0, total);

        }
        [Fact]
        public void ScanBasketWithItems()
        {
            // Arrange 
            List<UnitProduct> products = new List<UnitProduct>
            {
                new UnitProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Price = 5.2m
                },
                new UnitProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductB",
                    Code = "P102",
                    Price = 6.8m
                },
                new UnitProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductC",
                    Code = "P103",
                    Price = 10
                }
            };
            Basket basket = new Basket
            {
                UnitProducts = products
            };
            // Act
            decimal total = _register.Total(basket);

            //Assert
            Assert.Equal(22, total);

        }
        #endregion

        #region Test discount
        [Fact]
        public void ScanBasketNotAppliedDiscountDueToItemCountCondition()
        {
            // Arrange 
            List<UnitProduct> products = new List<UnitProduct>
            {
                new UnitProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Price = 5.2m ,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 3,
                            TotalPrice = 11.7m
                        }
                    }
                },
                new UnitProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Price = 5.2m ,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 3,
                            TotalPrice = 11.7m
                        }
                    }
                },
                new UnitProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductC",
                    Code = "P103",
                    Price = 10
                }
            };
            Basket basket = new Basket
            {
                UnitProducts = products
            };
            // Act
            decimal total = _register.Total(basket);

            //Assert
            Assert.Equal(20.4m, total);

        }
        [Fact]
        public void ScanBasketWithAppliedDiscountItemCountEqualsToTotal()
        {
            // Arrange 
            List<UnitProduct> products = new List<UnitProduct>
            {
                new UnitProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Price = 5.2m ,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 2,
                            TotalPrice = 8.5m,
                            StartDate = DateTime.Today
                        }
                    }
                },
                 new UnitProduct
                 {
                     ProductId = Guid.NewGuid(),
                     Name = "ProductA",
                     Code = "P101",
                     Price = 5.2m ,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 2,
                            TotalPrice = 8.5m,
                            StartDate = DateTime.Today
                        }
                    }
                 },
                new UnitProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductC",
                    Code = "P103",
                    Price = 10
                }
            };
            Basket basket = new Basket
            {
                UnitProducts = products
            };
            // Act
            decimal total = _register.Total(basket);

            //Assert
            Assert.Equal(18.5m, total);

        }
        [Fact]
        public void ScanBasketWithAppliedDiscountItemTotalSuperiorToItemCount()
        {
            // Arrange 
            List<UnitProduct> products = new List<UnitProduct>
            {
                new UnitProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Price = 5.2m ,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 2,
                            TotalPrice = 8.5m,
                            StartDate = DateTime.Today
                        }
                    }
                },
                 new UnitProduct
                 {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Price = 5.2m,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 2,
                            TotalPrice = 8.5m,
                            StartDate = DateTime.Today
                        }
                    }
                },
                 new UnitProduct
                 {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Price = 5.2m,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 2,
                            TotalPrice = 8.5m,
                            StartDate = DateTime.Today
                        }
                    }
                },
                 new UnitProduct
                 {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Price = 5.2m,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 2,
                            TotalPrice = 8.5m,
                            StartDate = DateTime.Today
                        }
                    }
                },
                 new UnitProduct
                 {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Price = 5.2m,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 2,
                            TotalPrice = 8.5m,
                            StartDate = DateTime.Today
                        }
                    }
                },
                new UnitProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductC",
                    Code = "P103",
                    Price = 10
                }
            };
            Basket basket = new Basket
            {
                UnitProducts = products
            };
            // Act
            decimal total = _register.Total(basket);

            //Assert
            // 2 discounts should be applied and one with no discount 8.5 * 2 + 5.2 + 10 = 32.2
            Assert.Equal(32.2m, total);

        }
        #endregion

        #region Test multi discount and validation with start and end date
        [Fact]
        public void ScanBasketDiscountItemWithNoEndDate()
        {
            // Arrange 
            List<UnitProduct> products = new List<UnitProduct>
            {
                new UnitProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Price = 5.2m ,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 2,
                            TotalPrice = 8.5m,
                            StartDate = DateTime.Today
                        }
                    }
                },
                 new UnitProduct
                 {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Price = 5.2m,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 2,
                            TotalPrice = 8.5m,
                            StartDate = DateTime.Today
                        }
                    }
                }
            };
            Basket basket = new Basket
            {
                UnitProducts = products
            };
            // Act
            decimal total = _register.Total(basket);

            //Assert
            Assert.Equal(8.5m, total);

        }
        [Fact]
        public void ScanBasketDiscountItemWithValidStartAndEndDate()
        {
            // Arrange 
            List<UnitProduct> products = new List<UnitProduct>
            {
                new UnitProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Price = 5.2m ,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 2,
                            TotalPrice = 8.5m,
                            StartDate = DateTime.Today,
                            EndDate = DateTime.Today
                        }
                    }
                },
                 new UnitProduct
                 {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Price = 5.2m,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 2,
                            TotalPrice = 8.5m,
                            StartDate = DateTime.Today,
                            EndDate = DateTime.Today
                        }
                    }
                }
            };
            Basket basket = new Basket
            {
                UnitProducts = products
            };
            // Act
            decimal total = _register.Total(basket);

            //Assert
            Assert.Equal(8.5m, total);

        }
        [Fact]
        public void ScanBasketDiscountItemWithInvalidEndDate()
        {
            // Arrange 
            List<UnitProduct> products = new List<UnitProduct>
            {
                new UnitProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Price = 5.2m ,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 2,
                            TotalPrice = 8.5m,
                            StartDate = DateTime.Today.AddDays(-1),
                            EndDate = DateTime.Today.AddDays(-1)
                        }
                    }
                },
                 new UnitProduct
                 {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Price = 5.2m,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 2,
                            TotalPrice = 8.5m,
                            StartDate = DateTime.Today.AddDays(-1),
                            EndDate = DateTime.Today.AddDays(-1)
                        }
                    }
                }
            };
            Basket basket = new Basket
            {
                UnitProducts = products
            };
            // Act
            decimal total = _register.Total(basket);

            //Assert
            Assert.Equal(10.4m, total);

        }
        [Fact]
        public void ScanBasketDiscountItemWithInvalidStartDate()
        {
            // Arrange 
            List<UnitProduct> products = new List<UnitProduct>
            {
                new UnitProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Price = 5.2m ,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 2,
                            TotalPrice = 8.5m,
                            StartDate = DateTime.Today.AddDays(-1),
                            EndDate = DateTime.Today.AddDays(-1)
                        }
                    }
                },
                 new UnitProduct
                 {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Price = 5.2m,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 2,
                            TotalPrice = 8.5m,
                            StartDate = DateTime.Today.AddDays(-1),
                            EndDate = DateTime.Today.AddDays(-1)
                        }
                    }
                }
            };
            Basket basket = new Basket
            {
                UnitProducts = products
            };
            // Act
            decimal total = _register.Total(basket);

            //Assert
            Assert.Equal(10.4m, total);

        }
        #endregion

        #region Test stock
        [Fact]
        public void NotInStocKItem()
        {
            // Arrange 
            List<UnitProduct> products = new List<UnitProduct>
            {
                new UnitProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Price = 5.2m ,
                    RemainingItemsCount = 2,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 2,
                            TotalPrice = 8.5m,
                            StartDate = DateTime.Today.AddDays(-1),
                            EndDate = DateTime.Today.AddDays(-1)
                        }
                    }
                },
                new UnitProduct
                {
                ProductId = Guid.NewGuid(),
                Name = "ProductA",
                Code = "P101",
                Price = 5.2m,
                RemainingItemsCount = 2,
                Discounts = new List<Discount>()
                {
                    new Discount
                    {
                        DiscountId = Guid.NewGuid(),
                        ItemCount = 2,
                        TotalPrice = 8.5m,
                        StartDate = DateTime.Today.AddDays(-1),
                        EndDate = DateTime.Today.AddDays(-1)
                    }
                }
            },
                new UnitProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Price = 5.2m ,
                    RemainingItemsCount = 2,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 2,
                            TotalPrice = 8.5m,
                            StartDate = DateTime.Today.AddDays(-1),
                            EndDate = DateTime.Today.AddDays(-1)
                        }
                    }
                },
            };
            Basket basket = new Basket
            {
                UnitProducts = products
            };
            // Act
            bool AreInStock = _register.AreProductsInStock(basket);

            //Assert
            Assert.False(AreInStock);
        }
        [Fact]
        public void AreInStocKItems()
        {
            // Arrange 
            List<UnitProduct> products = new List<UnitProduct>
            {
                new UnitProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Price = 5.2m ,
                    RemainingItemsCount = 2,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 2,
                            TotalPrice = 8.5m,
                            StartDate = DateTime.Today.AddDays(-1),
                            EndDate = DateTime.Today.AddDays(-1)
                        }
                    }
                },
                new UnitProduct
                {
                ProductId = Guid.NewGuid(),
                Name = "ProductA",
                Code = "P101",
                Price = 5.2m,
                RemainingItemsCount = 2,
                Discounts = new List<Discount>()
                {
                    new Discount
                    {
                        DiscountId = Guid.NewGuid(),
                        ItemCount = 2,
                        TotalPrice = 8.5m,
                        StartDate = DateTime.Today.AddDays(-1),
                        EndDate = DateTime.Today.AddDays(-1)
                    }
                }
            }
            };
            Basket basket = new Basket
            {
                UnitProducts = products
            };
            // Act
            bool AreInStock = _register.AreProductsInStock(basket);

            //Assert
            Assert.True(AreInStock);
        }
        #endregion

        #region Test weighted product
        [Fact]
        public void ScanBasketWithWeightedProducts()
        {
            // Arrange 
            List<WeightedProduct> products = new List<WeightedProduct>
            {
                new WeightedProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Weight = 1.2m,
                    PricePerKilo = 5.2m
                },
                new WeightedProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductB",
                    Code = "P102",
                    Weight = 0.8m,
                    PricePerKilo = 5.2m
                },
                new WeightedProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductC",
                    Code = "P103",
                    Weight = 1m,
                    PricePerKilo = 5.2m
                }
            };
            Basket basket = new Basket
            {
                WeightedProducts = products
            };
            // Act
            decimal total = _register.Total(basket);

            //Assert
            Assert.Equal(15.6m, total);

        }

        [Fact]
        public void ScanBasketWithDiscountOnWeightedProducts()
        {
            // Arrange 
            List<WeightedProduct> products = new List<WeightedProduct>
            {
                new WeightedProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Weight = 1.2m,
                    PricePerKilo = 5.2m,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 2,
                            TotalPrice = 8.5m,
                            StartDate = DateTime.Today
                        }
                    }
                },
                new WeightedProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Weight = 0.8m,
                    PricePerKilo = 5.2m,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 2,
                            TotalPrice = 8.5m,
                            StartDate = DateTime.Today
                        }
                    }
                },
                new WeightedProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Weight = 1m,
                    PricePerKilo = 5.2m,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 2,
                            TotalPrice = 8.5m,
                            StartDate = DateTime.Today
                        }
                    }
                }
            };
            Basket basket = new Basket
            {
                WeightedProducts = products
            };
            // Act
            decimal total = _register.Total(basket);

            //Assert
            Assert.Equal(13.7m, total);

        }
        #endregion

        #region Test mixed and weighted products
        [Fact]
        public void ScanBasketWithWeightedAndUnitProducts()
        {
            // Arrange 
            List<WeightedProduct> weightedProducts = new List<WeightedProduct>
            {
                new WeightedProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Weight = 1.2m,
                    PricePerKilo = 5.2m
                },
                new WeightedProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductB",
                    Code = "P102",
                    Weight = 0.8m,
                    PricePerKilo = 5.2m
                },
                new WeightedProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductC",
                    Code = "P103",
                    Weight = 1m,
                    PricePerKilo = 5.2m
                }
            };
            List<UnitProduct> unitProducts = new List<UnitProduct>
            {
                new UnitProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Price = 5.2m
                },
                new UnitProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductB",
                    Code = "P102",
                    Price = 6.8m
                },
                new UnitProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductC",
                    Code = "P103",
                    Price = 10
                }
            };
            Basket basket = new Basket
            {
                WeightedProducts = weightedProducts,
                UnitProducts = unitProducts
            };
            // Act
            decimal total = _register.Total(basket);

            //Assert
            Assert.Equal(37.6m, total);

        }

        [Fact]
        public void ScanBasketWithWeightedAndUnitProductsHavingBothDiscount()
        {
            // Arrange 
            List<WeightedProduct> weightedProducts = new List<WeightedProduct>
            {
                new WeightedProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Weight = 1.2m,
                    PricePerKilo = 5.2m,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 2,
                            TotalPrice = 8.5m,
                            StartDate = DateTime.Today
                        }
                    }
                },
                new WeightedProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Weight = 0.8m,
                    PricePerKilo = 5.2m,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 2,
                            TotalPrice = 8.5m,
                            StartDate = DateTime.Today
                        }
                    }
                },
                new WeightedProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Weight = 1m,
                    PricePerKilo = 5.2m,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 2,
                            TotalPrice = 8.5m,
                            StartDate = DateTime.Today
                        }
                    }
                }
            };
            List<UnitProduct> unitProducts = new List<UnitProduct>
            {
                new UnitProduct
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Price = 5.2m ,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 2,
                            TotalPrice = 8.5m,
                            StartDate = DateTime.Today
                        }
                    }
                },
                new UnitProduct
                 {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Price = 5.2m,
                    Discounts = new List<Discount>()
                    {
                        new Discount
                        {
                            DiscountId = Guid.NewGuid(),
                            ItemCount = 2,
                            TotalPrice = 8.5m,
                            StartDate = DateTime.Today
                        }
                    }
                }
            };
            Basket basket = new Basket
            {
                WeightedProducts = weightedProducts,
                UnitProducts = unitProducts
            };
            // Act
            decimal total = _register.Total(basket);

            //Assert
            Assert.Equal(22.2m, total);
        }
        #endregion

    }
}
