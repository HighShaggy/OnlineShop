using Microsoft.EntityFrameworkCore;
using OnlineShopWebApp.Interfaces;
using ShopDb.Interfaces;
using ShopDb.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopDb.Storages
{
    public class FavouritesStorage : IFavouritesStorage
    {
        readonly MyDbContext _dbContext;
        public FavouritesStorage(IProductStorage productStorage, MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<Product> LoadFavouritesList()
        {
            int userId = 0;
            var favouritesProducts = _dbContext.FavouritItems
                .Where(x => x.UserId == userId)
                .Include(x => x.Product)
                .Select(x => x.Product)
                .ToList();

            return favouritesProducts;
        }


        public void AddToFavouritesProducts(int id)
        {
            var productDb = _dbContext.ProductDb.FirstOrDefault(x => x.Id == id);
            var favouritesProducts = new List<Product>();
            int userId = 0;

            var fav = new Favourit
            {
                UserId = userId,
                Product = productDb,
            };
            _dbContext.FavouritItems.Add(fav);
            _dbContext.SaveChanges();
        }

        public void ClearFavouritesList()
        {
            _dbContext.FavouritItems.RemoveRange(_dbContext.FavouritItems);
            _dbContext.SaveChanges();
        }
        public void RemoveFavouritesProduct(int id)
        {
            int userId = 0;
            var favouritToRemove = _dbContext.FavouritItems
                    .FirstOrDefault(f => f.UserId == userId && f.Product.Id == id);

            if (favouritToRemove != null)
            {
                _dbContext.FavouritItems.Remove(favouritToRemove);
                _dbContext.SaveChanges();
            }
        }
    }
}
