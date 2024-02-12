using ShopDb.Models;
using System.Collections.Generic;

namespace ShopDb
{
    public interface ICompareStorage
    {
        List<Product> LoadCompareItems();
        void AddToCompare(int id);
        void ClearCompareList();
        void RemoveCompareProduct(int id);
    }
}
