using System.Collections.Generic;

namespace supermarketapp.Models
{
    public class Cart
    {
        public IList<CartItem> Items { get; set; }

        public Cart()
        {
            Items = new List<CartItem>();
        }

        public void AddItem(CartItem item)
        {
            Items.Add(item);
        }
    }
}
