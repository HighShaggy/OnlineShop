using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using ShopDb.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class FavouritesController : Controller
    {
        readonly IFavouritesStorage _favouritesStorage;
        readonly ICartStorage _cartStorage;

        public FavouritesController(IFavouritesStorage favouritesStorage, ICartStorage cartStorage)
        {
            _favouritesStorage = favouritesStorage;
            _cartStorage = cartStorage;
        }

        public IActionResult FavouritesList()
        {
            ViewBag.CartCount = _cartStorage.LoadCartCount();
            return View(Mapping.Maps.ToProductListViewModel(_favouritesStorage.LoadFavouritesList()));
        }

        public IActionResult AddToFavourites(int id)
        {
            _favouritesStorage.AddToFavouritesProducts(id);
            return RedirectToAction("index", "home");
        }

        public IActionResult ClearAllFavourites()
        {
            _favouritesStorage.ClearFavouritesList();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult RemoveFavouritProduct(int id)
        {
            _favouritesStorage.RemoveFavouritesProduct(id);
            return RedirectToAction("FavouritesList", "Favourites");
        }
    }
}
