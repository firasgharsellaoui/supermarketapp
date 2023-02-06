using supermarketapp.Interfaces;
using supermarketapp.Models;
using supermarketapp.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace supermarketapp.tests
{
    public class RegisterTest
    {        
        private readonly ICashRegister _register;
        public RegisterTest()
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
                new Product {ProductId = new Guid(),Name = "ProductA",Code = "P101",Price = 5.2m},
                new Product {ProductId = new Guid(),Name = "ProductA",Code = "P102",Price = 6.8m},
                new Product {ProductId = new Guid(),Name = "ProductA",Code = "P103",Price = 10}
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
    }
}
