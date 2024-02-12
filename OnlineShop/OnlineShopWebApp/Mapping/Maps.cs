using OnlineShopWebApp.Models;
using ShopDb.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Mapping
{
    public static class Maps
    {
        public static List<CartItemViewModel> ToCartItemListViewModels(List<CartItem> cartItems)
        {
            var cartModels = new List<CartItemViewModel>();

            foreach (var cartItem in cartItems)
            {
                cartModels.Add(ToCartItemViewModel(cartItem));
            }
            return cartModels;
        }
        public static CartItemViewModel ToCartItemViewModel(CartItem item)
        {
            return new CartItemViewModel()
            {
                Id = item.Id,
                Product = ToProductViewModel(item.Product),
                ProductQuantity = item.ProductQuantity,
            };
        }

        public static CartViewModel ToCartViewModel(Cart cart)
        {
            if (cart == null)
            {
                return null;
            }
            return new CartViewModel()
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = ToCartItemListViewModels(cart.CartItems)
            };
        }
        public static UserViewModel ToUserViewModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
            };
        }

        public static List<UserViewModel> ToUserListViewModel(List<User> users)
        {
            var listUsersViewModel = new List<UserViewModel>();

            foreach (var product in users)
            {
                listUsersViewModel.Add(ToUserViewModel(product));
            }
            return listUsersViewModel;
        }


        public static List<ProductViewModel> ToProductListViewModel(List<Product> products)
        {
            var listProductsViewModel = new List<ProductViewModel>();

            foreach (var product in products)
            {
                listProductsViewModel.Add(ToProductViewModel(product));
            }
            return listProductsViewModel;
        }

        public static List<OrderViewModel> ToOrderListViewModel(List<Order> orders)
        {
            var listOrdersViewModel = new List<OrderViewModel>();

            foreach (var order in orders)
            {
                listOrdersViewModel.Add(ToOrderViewModel(order));
            }
            return listOrdersViewModel;
        }

        public static OrderViewModel ToOrderViewModel(Order order)
        {
            return new OrderViewModel()
            {
                OrderId = order.OrderId,
                OrderStatus = order.OrderStatus,
                ShippingAddress = order.ShippingAddress,
                CustomerName = order.CustomerName,
                ProductCart = order.ProductCart,
            };
        }
        public static ProductViewModel ToProductViewModel(Product product)
        {
            return new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Cost = product.Cost,
                ImagePath = product.ImagePath,
            };
        }

        public static RoleViewModel ToRoleViewModel(Role roleName)
        {
            return new RoleViewModel()
            {
                Name= roleName.Name,
            };
        }

        public static List<RoleViewModel> ToRoleListViewModel(List<Role> roles)
        {
            var listRoleViewModel = new List<RoleViewModel>();

            foreach (var role in roles)
            {
                listRoleViewModel.Add(ToRoleViewModel(role));
            }
            return listRoleViewModel;
        }
    }
}
