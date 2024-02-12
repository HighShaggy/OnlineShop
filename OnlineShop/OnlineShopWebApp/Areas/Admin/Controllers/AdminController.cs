using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using System.Linq;
using static ShopDb.Storages.OrderStorage;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AdminController : Controller
    {
        readonly IOrderStorage _orderStorage;

        public AdminController(IOrderStorage orderStorage)
        {
            _orderStorage = orderStorage;
        }

        public IActionResult AdminPanel()
        {
            return View();
        }

        public IActionResult WatchOrders()
        {
            return View(Mapping.Maps.ToOrderListViewModel(_orderStorage.LoadOrders()));
        }
        
        [HttpGet]
        public IActionResult UpdateOrderStatus(int orderId, OrderStatus status)
        {
            //    //var orders = _orderStorage.LoadOrders();
            //    //var existingOrder = orders.FirstOrDefault(p => p.OrderId == orderId);
            //    //if (existingOrder != null)
            //    //{
            //    //    existingOrder.OrderStatus = status;
            //    //}
            //_orderStorage.UpdateOrderStatus(existingOrder);
            return RedirectToAction("WatchOrders", "Admin");
        }
    }
}
