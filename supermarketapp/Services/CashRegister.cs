using supermarketapp.Interfaces;
using supermarketapp.Models;

namespace supermarketapp.Services
{
    public class CashRegister : ICashRegister
    {
        public decimal Total(Basket basket)
        {
            decimal total = 0;
            if (basket != null && basket.Products != null)
            {
                basket.Products.ForEach(product =>
                {
                    total += product.Price;
                });
            }
            return total;
        }
    }
}
