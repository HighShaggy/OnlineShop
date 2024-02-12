using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using ShopDb.Interfaces;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ProductController : Controller
    {
        readonly IProductStorage _productStorage;

        public ProductController(IProductStorage productStorage)
        {
            _productStorage = productStorage;
        }

        public IActionResult WatchProducts()
        {
            
            return View(Mapping.Maps.ToProductListViewModel(_productStorage.LoadProducts()));
        }

        public IActionResult RemoveProduct(int id)
        {
            _productStorage.RemoveProduct(id);
            return RedirectToAction("WatchProducts", "Product");
        }

        public IActionResult EditProduct(int id, string Name, decimal Cost, string Description)
        {
            var products = _productStorage.LoadProducts();
            var product = products.FirstOrDefault(p => p.Id == id);
            _productStorage.EditProduct(id, Name, Cost, Description);
            return View(product);
        }

        public IActionResult AddProduct(string Name, decimal Cost, string Description)
        {
            if (string.IsNullOrWhiteSpace(Name) || Cost <= 0 || string.IsNullOrWhiteSpace(Description))
            {
                return View();
            }
            else
            {
                _productStorage.AddProduct(Name, Cost, Description, "~/images/products/SteelseriesQck.webp");
                return RedirectToAction("WatchProducts", "Product");
            }
        }
    }
}
