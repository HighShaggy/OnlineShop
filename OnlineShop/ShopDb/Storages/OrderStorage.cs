using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineShopWebApp.Interfaces;
using ShopDb.Interfaces;
using ShopDb.Models;

namespace ShopDb.Storages
{
    public class OrderStorage : IOrderStorage
    {
        readonly MyDbContext _dbContext;
        public OrderStorage(ICartStorage shoppingCart, MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public enum OrderStatus
        {
            Обработан,
            Отправлен,
            Доставлен,
            Отменен
        }

        public void SaveUserOrder(string customerName, string shippingAddress, OrderStatus orderStatus)
        {
            int userId = 0;
            var userCart = _dbContext.CartDb.Include(x => x.CartItems).ThenInclude(x => x.Product).FirstOrDefault(x => x.UserId == userId);
            var userOrder = new Order()
            {
                CustomerName = customerName,
                ShippingAddress = shippingAddress,
                OrderStatus = orderStatus.ToString(),
                ProductCart = userCart
            };
            _dbContext.Orders.Add(userOrder);
            _dbContext.SaveChanges();
        }
        public List<Order> LoadOrders()
        {
            return _dbContext.Orders.ToList(); 
        }
        public void UpdateOrderStatus(Order item)
        {
            var orders = LoadOrders();
            if (orders != null)
            {
                var order = orders.FirstOrDefault(o => o.OrderId == item.OrderId);
                if (order != null)
                {
                    order.OrderStatus = item.OrderStatus;
                }
            }
        }
    }
}
