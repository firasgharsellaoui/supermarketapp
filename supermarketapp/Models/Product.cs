using supermarketapp.Enum;
using System;

namespace supermarketapp.Models
{
    public class Product
    {
        public Product(Guid productId, string name,int code , decimal price, WeightUnit weightUnit)
        {
            ProductId = productId;
            Name = name;
            Code = code;
            Price = price;
            WeightUnit = weightUnit;
        }

        /// <summary>
        /// Unique identifier of the product.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Name of the product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product code ( business identifier ).
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Product price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Product measurment unit (per item, weight, volume, etc.).
        /// </summary>
        public WeightUnit WeightUnit { get; set; }

    }
}
