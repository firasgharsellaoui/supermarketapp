using System.Collections.Generic;

namespace supermarketapp.Models
{
    public class ProductCatalog
    {
        ProductCatalog()
        {
            UnitProducts = new List<UnitProduct>();
            WeightedProducts = new List<WeightedProduct>();
        }
        public List<UnitProduct> UnitProducts { get; set; }
        public List<WeightedProduct> WeightedProducts { get; set; }

    }
}
