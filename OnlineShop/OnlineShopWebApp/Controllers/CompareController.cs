using Microsoft.AspNetCore.Mvc;
using ShopDb;
using ShopDb.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class CompareController : Controller
    {
        readonly ICompareStorage _compareStorage;
        readonly ICartStorage _cartStorage;

        public CompareController(ICompareStorage compareStorage, ICartStorage cartStorage)
        {
            _compareStorage = compareStorage;
            _cartStorage = cartStorage;
        }
        public IActionResult CompareProducts()
        {
            ViewBag.CartCount = _cartStorage.LoadCartCount();
            return View(Mapping.Maps.ToProductListViewModel(_compareStorage.LoadCompareItems()));
        }
        public IActionResult AddToCompare(int id)
        {
            _compareStorage.AddToCompare(id);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult RemoveCompareProduct(int id)
        {
            _compareStorage.RemoveCompareProduct(id);
            return RedirectToAction("CompareProducts", "Compare");
        }
        public IActionResult ClearCompareList()
        {
            _compareStorage.ClearCompareList();
            return RedirectToAction("CompareProducts", "Compare");
        }
    }
}
