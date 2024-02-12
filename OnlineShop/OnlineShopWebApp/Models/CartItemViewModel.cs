using ShopDb.Models;

namespace OnlineShopWebApp.Models
{
    public class CartItemViewModel
    {
        public int Id { get; set; }
        public ProductViewModel Product { get; set; }
        public int ProductQuantity { get; set; }
    }
}
