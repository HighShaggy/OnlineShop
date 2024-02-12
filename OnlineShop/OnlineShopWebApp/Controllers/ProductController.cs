using Microsoft.AspNetCore.Mvc;
using ShopDb.Interfaces;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductStorage _productStorage;

        public ProductController (IProductStorage productStorage)
        {
            _productStorage = productStorage;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var products = _productStorage.LoadProducts();
            var item = products.FirstOrDefault(x => x.Id == id);
            if (id == 0) return View(products);
            return View(item == null ? null : new[] { item });
        }
       
        public IActionResult Search(string searchText)
        {
            if (searchText != null)
            {
                var products = _productStorage.LoadProducts();
                var itemFind = products.Where(product => product.Name.ToLower().Contains(searchText.ToLower())).ToList();
                return View(Mapping.Maps.ToProductListViewModel(itemFind));
            }
            else
                return RedirectToAction("Index", "Home");
        }
    }
}
