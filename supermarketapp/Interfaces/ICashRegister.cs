using supermarketapp.Models;

namespace supermarketapp.Interfaces
{
    public interface ICashRegister
    {
        decimal Total(Basket basket);
    }
}
