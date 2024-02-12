using Microsoft.AspNetCore.Mvc;
using ShopDb.Interfaces;


namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        readonly ICartStorage _shoppingCart;

        public CartController(ICartStorage cartStorage)
        {
            _shoppingCart = cartStorage;
        }

        public IActionResult WatchCart()
        {
            var cart = _shoppingCart.LoadCart();
            return View(Mapping.Maps.ToCartViewModel(cart));
        }

        public IActionResult AddToCart(int id)
        {
            _shoppingCart.AddToCart(id);
            return RedirectToAction("WatchCart", "Cart");
        }

        public IActionResult DecreaseQuantity(int id)
        {
            _shoppingCart.DecreaseQuantity(id);
            return RedirectToAction("WatchCart", "Cart");
        }

        public IActionResult IncreaseQuantity(int id)
        {
            _shoppingCart.IncreaseQuantity(id);
            return RedirectToAction("WatchCart", "Cart");
        }

        public IActionResult ClearCart()
        {
            _shoppingCart.ClearCart();
            return RedirectToAction("Index", "Home");
        }
    }
}