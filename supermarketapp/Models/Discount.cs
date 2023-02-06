using System;

namespace supermarketapp.Models
{
    public class Discount
    {
        // TODO : Add  (validity Period) : start date and end date
        public Guid DiscountId { get; set; }
        public decimal ItemCount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
