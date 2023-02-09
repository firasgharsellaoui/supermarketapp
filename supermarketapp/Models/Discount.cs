using supermarketapp.Enum;
using System;

namespace supermarketapp.Models
{
    public class Discount
    {
        public Guid DiscountId { get; set; }
        public decimal ItemCount { get; set; }
        public WeightUnit Unit { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
