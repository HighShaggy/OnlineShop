using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;
using ShopDb.Interfaces;
using X.PagedList;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        readonly ILogger<HomeController> _logger;

        readonly IProductStorage _productStorage;

        readonly ICartStorage _cartStorage;
        

        public HomeController(ILogger<HomeController> logger, IProductStorage productStorage, ICartStorage cartStorage)
        {
            _cartStorage = cartStorage;
            _productStorage = productStorage;
            _logger = logger;
        }
         
        public IActionResult Index(int? page)
        {
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            ViewBag.CartCount = _cartStorage.LoadCartCount();
            var products = _productStorage.LoadProducts().OrderBy(p => p.Id).ToList();
            return View(Mapping.Maps.ToProductListViewModel(products).ToPagedList(pageNumber, pageSize));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
