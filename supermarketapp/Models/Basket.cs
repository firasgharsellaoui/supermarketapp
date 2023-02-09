using System.Collections.Generic;

namespace supermarketapp.Models
{
    public class Basket
    {
        public Basket() 
        { 
            UnitProducts = new List<UnitProduct>();
            WeightedProducts = new List<WeightedProduct>();
        }
        public List<UnitProduct> UnitProducts { get; set; }
        public List<WeightedProduct> WeightedProducts { get; set; }

    }
}
