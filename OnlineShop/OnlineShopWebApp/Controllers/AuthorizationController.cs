using Microsoft.AspNetCore.Mvc;
using ShopDb.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class AuthorizationController : Controller
    {
        readonly IUserStorage _userStorage;
        readonly ICartStorage _cartStorage;

        public AuthorizationController(IUserStorage userStorage, ICartStorage cartStorage)
        {
            _userStorage = userStorage;
            _cartStorage = cartStorage;
        }
        public IActionResult RegistrationForm()
        {
            ViewBag.CartCount = _cartStorage.LoadCartCount();
            return View();
        }

        public IActionResult LoginForm()
        {
            ViewBag.CartCount = _cartStorage.LoadCartCount();
            return View();
        }

        [HttpPost]
        public IActionResult AcceptLogin(string name, string password)
        {
            var loginResult = _userStorage.UserLogin(name, password);

            if (!loginResult)
            {
                TempData["ErrorMessage"] = "Неверный логин или пароль";
                return RedirectToAction("Error", "Home");
            }
            return View();
        }

        public IActionResult AcceptRegistration(string name, string password)
        {
            _userStorage.UserRegistration(name, password);
            return View();
        }
    }
}
