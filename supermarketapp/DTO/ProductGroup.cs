using supermarketapp.Models;

namespace supermarketapp.DTO
{
    public class ProductGroup
    {
        public decimal Total { get; set; }
        public UnitProduct UnitProduct { get; set; }
        public WeightedProduct WeightedProduct { get; set; }

    }
}
