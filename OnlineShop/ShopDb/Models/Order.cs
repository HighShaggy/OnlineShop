using System.Collections.Generic;

namespace ShopDb.Models
{


    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string CustomerName { get; set; }
        public string ShippingAddress { get; set; }

        public Cart ProductCart { get; set; }

        public string OrderStatus { get; set; }
    }

}
