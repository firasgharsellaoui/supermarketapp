using supermarketapp.Enum;

namespace supermarketapp.Models
{
    public class WeightedProduct : Product 
    {
        public decimal PricePerKilo { get; set; }

        public WeightUnit Unit { get; set; }

        public decimal Weight { get; set; }

        public decimal RemainingWeight { get; set; }

        public decimal Price { get; set; }
    }
}
