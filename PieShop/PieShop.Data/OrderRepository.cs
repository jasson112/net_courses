using PieShop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PieShop.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PieShopDbContext pieShopDbContext;
        private readonly CartRepository cartRepository;

        public OrderRepository(PieShopDbContext pieShopDbContext, CartRepository cartRepository)
        {
            this.pieShopDbContext = pieShopDbContext;
            this.cartRepository = cartRepository;
        }

        public void CreateOrder(Order order)
        {
            order.Placed = DateTime.Now;
            pieShopDbContext.Orders.Add(order);

            var cartItems = cartRepository.CartItems;

            foreach (var cartItem in cartItems) {
                var Detail = new OrderDetail()
                {
                    Amount = cartItem.Amount,
                    PieId = cartItem.Pie.id,
                    OrderId = order.id,
                    Price = cartItem.Pie.Price
                };

                pieShopDbContext.OrderDetails.Add(Detail);
            }

            pieShopDbContext.SaveChanges();
        }
    }
}
