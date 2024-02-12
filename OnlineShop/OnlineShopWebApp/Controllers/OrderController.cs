using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using ShopDb;
using ShopDb.Interfaces;
using static ShopDb.Storages.OrderStorage;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        readonly ICartStorage _cartStorage;
        readonly IOrderStorage _orderStorage;
        readonly MyDbContext _dbContext;

        public OrderController(ICartStorage cartStorage, IOrderStorage orderStorage, MyDbContext dbContext)
        {
            _orderStorage = orderStorage;
            _cartStorage = cartStorage;
            _dbContext = dbContext;
        }

        public IActionResult WatchOrder()
        {
            ViewBag.CartCount = _cartStorage.LoadCartCount();
            return View();
        }

        public IActionResult OrderAccept(string name, string address)
        {
            _orderStorage.SaveUserOrder(name, address, OrderStatus.Обработан);
            return View();
        }
    }
}