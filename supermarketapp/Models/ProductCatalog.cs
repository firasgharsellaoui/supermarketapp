using System.Collections.Generic;

namespace supermarketapp.Models
{
    public class ProductCatalog
    {
        ProductCatalog() 
        {
            Products = new List<Product>();
        }
        public List<Product> Products { get; set;}
    }
}
