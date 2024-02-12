
using ShopDb.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<CartItemViewModel> Items { get; set; }

    }
}

