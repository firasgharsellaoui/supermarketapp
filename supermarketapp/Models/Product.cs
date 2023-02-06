using System;

namespace supermarketapp.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }

        public string Name { get; set; }

        // TODO : Add extra validation to check if the code is unique or not
        public string Code { get; set; }

        public decimal Price { get; set; }

        public Discount Discount { get; set; }

    }
}
