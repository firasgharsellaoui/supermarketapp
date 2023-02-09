using supermarketapp.Enum;
using System;
using System.Collections.Generic;

namespace supermarketapp.Models
{
    public class Product
    {
        public Product()
        {
            Discounts = new List<Discount>();
        }
        public Guid ProductId { get; set; }

        public string Name { get; set; }

        // TODO : Add extra validation to check if the code is unique or not
        public string Code { get; set; }

        public IEnumerable<Discount> Discounts { get; set; }

    }
}
