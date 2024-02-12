using System.Collections.Generic;

namespace ShopDb.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
