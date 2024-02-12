using ShopDb.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Interfaces
{
    public interface IFavouritesStorage
    {
        List<Product> LoadFavouritesList();

        void AddToFavouritesProducts(int id);

        void ClearFavouritesList();

        void RemoveFavouritesProduct(int id);
    }
}
