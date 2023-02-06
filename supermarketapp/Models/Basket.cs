using System.Collections.Generic;

namespace supermarketapp.Models
{
    public class Basket
    {
        public Basket() 
        { 
            Products= new List<Product>();
        }
        public List<Product> Products { get; set; }
    }
}
