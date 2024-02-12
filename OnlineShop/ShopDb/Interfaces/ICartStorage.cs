using ShopDb.Models;

namespace ShopDb.Interfaces
{
    public interface ICartStorage
    {
        void AddToCart(int id);

        Cart LoadCart();

        void DecreaseQuantity(int id);
        void IncreaseQuantity(int id);
        void ClearCart();
        int? LoadCartCount();
    }
}
