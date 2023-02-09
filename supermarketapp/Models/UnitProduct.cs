namespace supermarketapp.Models
{
    public class UnitProduct : Product
    {
        public decimal Price { get; set; }

        public decimal RemainingItemsCount { get; set; }
    }
}
