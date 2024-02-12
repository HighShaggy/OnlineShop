using ShopDb.Models;
using ShopDb.Storages;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string ShippingAddress { get; set; }

        public Cart ProductCart { get; set; }
        public string OrderStatus { get; set; }
    }
}
