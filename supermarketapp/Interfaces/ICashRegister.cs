using supermarketapp.DTO;
using supermarketapp.Models;
using System.Collections.Generic;

namespace supermarketapp.Interfaces
{
    public interface ICashRegister
    {
        decimal Total(Basket basket);
        bool AreProductsInStock(Basket basket);
    }
}
