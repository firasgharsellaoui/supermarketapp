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
            List<Product> products = new List<Product>
            {
                new Product 
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductA",
                    Code = "P101",
                    Price = 5.2m
                },
                new Product 
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductB",
                    Code = "P102",
                    Price = 6.8m
                },
                new Product 
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductC",
                    Code = "P103",
                    Price = 10
                }
            };
            Basket basket = new Basket
            {
                Products = products
            };
            // Act
            decimal total = _register.Total(basket);

            //Assert
            Assert.Equal(22, total);

        }
        [Fact]
        public void ScanBasketNotAppliedDiscountDueToItemCountCondition()
        {
            // Arrange 
            List<Product> products = new List<Product>
            {
                new Product 
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
                new Product
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
                new Product 
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductC",
                    Code = "P103",
                    Price = 10
                }
            };
            Basket basket = new Basket
            {
                Products = products
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
            List<Product> products = new List<Product>
            {
                new Product 
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
                 new Product 
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
                new Product 
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductC",
                    Code = "P103",
                    Price = 10
                }
            };
            Basket basket = new Basket
            {
                Products = products
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
            List<Product> products = new List<Product>
            {
                new Product 
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
                 new Product 
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
                 new Product
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
                 new Product
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
                 new Product
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
                new Product 
                {
                    ProductId = Guid.NewGuid(),
                    Name = "ProductC",
                    Code = "P103",
                    Price = 10
                }
            };
            Basket basket = new Basket
            {
                Products = products
            };
            // Act
            decimal total = _register.Total(basket);

            //Assert
            // 2 discounts should be applied and one with no discount 8.5 * 2 + 5.2 + 10 = 32.2
            Assert.Equal(32.2m, total);

        }
        [Fact]
        public void ScanBasketDiscountItemWithNoEndDate()
        {
            // Arrange 
            List<Product> products = new List<Product>
            {
                new Product
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
                 new Product
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
                Products = products
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
            List<Product> products = new List<Product>
            {
                new Product
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
                 new Product
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
                Products = products
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
            List<Product> products = new List<Product>
            {
                new Product
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
                 new Product
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
                Products = products
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
            List<Product> products = new List<Product>
            {
                new Product
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
                 new Product
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
                Products = products
            };
            // Act
            decimal total = _register.Total(basket);

            //Assert
            Assert.Equal(10.4m, total);

        }
    }
}