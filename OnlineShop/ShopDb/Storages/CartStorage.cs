using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ShopDb.Interfaces;
using ShopDb.Models;

namespace ShopDb.Storages
{
    public class CartStorage : ICartStorage
    {
        readonly MyDbContext _dbContext;

        public CartStorage(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Cart LoadCart()
        {
            int userId = 0;
            return _dbContext.CartDb.Include(x => x.CartItems).ThenInclude(x => x.Product).FirstOrDefault(x => x.UserId == userId);
        }

        public void AddToCart(int id)
        {
            var productDb = _dbContext.ProductDb.FirstOrDefault(x => x.Id == id);
            int userId = 0;
            var cart = _dbContext.CartDb.Include(x => x.CartItems).ThenInclude(x => x.Product).FirstOrDefault(x => x.UserId == userId);

            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    CartItems = new List<CartItem>()
                };

                var cartItem = new CartItem
                {
                    Product = productDb,
                    ProductQuantity = 1
                };

                cart.CartItems.Add(cartItem);
                _dbContext.CartDb.Add(cart);
            }
            else
            {
                var cartItem = cart.CartItems.FirstOrDefault(x => x.Product == productDb);
                if (cartItem == null)
                {
                    cartItem = new CartItem
                    {
                        Product = productDb,
                        ProductQuantity = 1
                    };
                    cart.CartItems.Add(cartItem);
                }
                else
                {
                    cartItem.ProductQuantity++;
                }
            }
            _dbContext.SaveChanges();
        }

        public void DecreaseQuantity(int id)
        {
            var productDb = _dbContext.ProductDb.FirstOrDefault(x => x.Id == id);
            int userId = 0;
            var cart = _dbContext.CartDb.Include(x => x.CartItems).ThenInclude(x => x.Product).FirstOrDefault(x => x.UserId == userId);
            var cartItem = cart.CartItems.FirstOrDefault(x => x.Product == productDb);
            cartItem.ProductQuantity--;
            if (cartItem.ProductQuantity <= 0)
            {
                _dbContext.CartItems.Remove(cartItem);
            }
            _dbContext.SaveChanges();
        }
        public void IncreaseQuantity(int id)
        {
            var productDb = _dbContext.ProductDb.FirstOrDefault(item => item.Id == id);
            int userId = 0;
            var cart = _dbContext.CartDb.Include(x => x.CartItems).ThenInclude(x => x.Product).FirstOrDefault(x => x.UserId == userId);
            var cartItem = cart.CartItems.FirstOrDefault(x => x.Product == productDb);
            cartItem.ProductQuantity++;
            _dbContext.SaveChanges();
        }
        public int? LoadCartCount()
        {
            int userId = 0;
            var cart = _dbContext.CartDb.Include(x => x.CartItems).ThenInclude(x => x.Product).FirstOrDefault(x => x.UserId == userId);
            if (cart?.CartItems == null || cart.CartItems.Count == 0) return null;
            else
                return cart.CartItems.Count;
        }
        public void ClearCart()
        {
            int userId = 0;
            var cart = _dbContext.CartDb.Include(x => x.CartItems).ThenInclude(x => x.Product).FirstOrDefault(x => x.UserId == userId);
            _dbContext.CartDb.RemoveRange(cart);
            _dbContext.SaveChanges();
        }
    }
}