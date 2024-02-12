using System.Collections.Generic;

namespace OnlineShop.Db
{


    public class Orders
    {
        //public List<CartDb> ProductList { get; set; }
        public int OrderId { get; set; }
        public int UserId {  get; set; }
        public string CustomerName { get; set; }
        public string ShippingAddress { get; set; }

        public string OrderStatus {  get; set; }
    }

}
