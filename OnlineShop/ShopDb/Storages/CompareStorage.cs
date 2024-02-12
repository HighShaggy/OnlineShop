using Microsoft.EntityFrameworkCore;
using ShopDb.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopDb.Storages
{
    public class CompareStorage : ICompareStorage
    {
        readonly MyDbContext _dbContext;
        public CompareStorage(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Product> LoadCompareItems()
        {
            int userId = 0;
            var compareProducts = _dbContext.CompareItems
                .Where(x => x.UserId == userId)
                .Include(x => x.Product)
                .Select(x => x.Product)
                .ToList();
            return compareProducts;
        }

        public void AddToCompare(int id)
        {
            var productDb = _dbContext.ProductDb.FirstOrDefault(x => x.Id == id);
            int userId = 0;
            var compareItem = new Compare
            {
                UserId = userId,
                Product = productDb,
            };
            _dbContext.CompareItems.Add(compareItem);
            _dbContext.SaveChanges();
        }
        public void ClearCompareList()
        {
            _dbContext.CompareItems.RemoveRange(_dbContext.CompareItems);
            _dbContext.SaveChanges();
        }

        public void RemoveCompareProduct(int id)
        {
            int userId = 0;
            var compareToRemove = _dbContext.CompareItems
                    .FirstOrDefault(f => f.UserId == userId && f.Product.Id == id);
            if (compareToRemove != null)
            {
                _dbContext.CompareItems.Remove(compareToRemove);
                _dbContext.SaveChanges();
            }
        }
    }
}
