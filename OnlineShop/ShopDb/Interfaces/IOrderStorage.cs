using ShopDb.Models;
using System.Collections.Generic;
using static ShopDb.Storages.OrderStorage;

namespace OnlineShopWebApp.Interfaces
{
    public interface IOrderStorage
    {
        void SaveUserOrder(string customerName, string shippingAddress, OrderStatus orderStatus);
        List<Order> LoadOrders();
        void UpdateOrderStatus(Order item);
    }
}