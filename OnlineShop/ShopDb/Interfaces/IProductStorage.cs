using ShopDb.Models;
using System.Collections.Generic;

namespace ShopDb.Interfaces
{
    public interface IProductStorage
    {
        List<Product> LoadProducts();
        public void RemoveProduct(int id);

        void EditProduct(int id, string Name, decimal Cost, string Description);

        void AddProduct(string Name, decimal Cost, string Description, string ImagePath);
    }
}
