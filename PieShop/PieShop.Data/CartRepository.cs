using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PieShop.Model;

namespace PieShop.Data
{
    public class CartRepository
    {
        private readonly PieShopDbContext pieShopDbContext;
        public string CartId { get; set; }
        public List<CartItem> CartItems { get; set; }

        public CartRepository(PieShopDbContext pieShopDbContext)
        {
            this.pieShopDbContext = pieShopDbContext;
        }

        public static CartRepository GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<PieShopDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new CartRepository(context) { CartId = cartId };
        }

        public void AddToCart(Pie pie, int amount)
        {
            var shoppingCartItem =
                    pieShopDbContext.CartItems.SingleOrDefault(
                        s => s.Pie.id == pie.id && s.CartId == CartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new CartItem
                {
                    CartId = CartId,
                    Pie = pie,
                    Amount = 1
                };

                pieShopDbContext.CartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            pieShopDbContext.SaveChanges();
        }

        public int RemoveFromCart(Pie pie)
        {
            var shoppingCartItem =
                    pieShopDbContext.CartItems.SingleOrDefault(
                        s => s.Pie.id == pie.id && s.CartId == CartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    pieShopDbContext.CartItems.Remove(shoppingCartItem);
                }
            }

            pieShopDbContext.SaveChanges();

            return localAmount;
        }

        public List<CartItem> GetCartItems()
        {
            return CartItems ??
                   (CartItems =
                       pieShopDbContext.CartItems.Where(c => c.CartId == CartId)
                           .Include(s => s.Pie)
                           .ToList());
        }

        public void ClearCart()
        {
            var cartItems = pieShopDbContext
                .CartItems
                .Where(cart => cart.CartId == CartId);

            pieShopDbContext.CartItems.RemoveRange(cartItems);

            pieShopDbContext.SaveChanges();
        }

        public decimal GetCartTotal()
        {
            var total = pieShopDbContext.CartItems.Where(c => c.CartId == CartId)
                .Select(c => c.Pie.Price * c.Amount).Sum();
            return total;
        }
    }
}
