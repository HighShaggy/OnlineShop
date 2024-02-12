using System.Collections.Generic;
using System.Linq;
using ShopDb.Interfaces;
using ShopDb.Models;

namespace ShopDb.Storages
{
    public class ProductStorage : IProductStorage
    {
        readonly MyDbContext _dbContext;

        public ProductStorage(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<Product> LoadProducts()
        {
            List<Product> products = _dbContext.ProductDb
        .Select(p => new Product(p.Id, p.Name, p.Description, p.Cost, p.ImagePath))
        .ToList();
            return products;
        }
        public void RemoveProduct(int id)
        {
            _dbContext.Database.EnsureCreated();
            var productDb = _dbContext.ProductDb.FirstOrDefault(item => item.Id == id);
            if (productDb != null)
            {
                _dbContext.ProductDb.Remove(productDb);
                _dbContext.SaveChanges();
            }
        }
        public void EditProduct(int id, string Name, decimal Cost, string Description)
        {
            if (Name != null)
            {
                var existingProduct = _dbContext.ProductDb.FirstOrDefault(x => x.Id == id);
                if (existingProduct != null)
                {
                    existingProduct.Name = Name;
                    existingProduct.Cost = Cost;
                    existingProduct.Description = Description;
                    existingProduct.ImagePath = "~/images/products/SteelseriesQck.webp";
                }
                _dbContext.SaveChanges();
            }
        }
        public void AddProduct(string Name, decimal Cost, string Description, string ImagePath)
        {
            _dbContext.Database.EnsureCreated();
            var productDb = new Product(Name, Description, Cost, ImagePath);
            _dbContext.ProductDb.Add(productDb);
            _dbContext.SaveChanges();
        }
    }
}
