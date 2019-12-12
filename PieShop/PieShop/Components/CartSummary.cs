using Microsoft.AspNetCore.Mvc;
using PieShop.Data;
using PieShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Components
{
    public class CartSummary : ViewComponent
    {
        private readonly CartRepository cartRepository;

        public CartSummary(CartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public IViewComponentResult Invoke() {
            var items = cartRepository.GetCartItems();
            cartRepository.CartItems = items;

            var cartViewModel = new CartViewModel {
                Cart = cartRepository,
                CartTotal = cartRepository.GetCartTotal()
            };

            return View(cartViewModel);
        }
    }
}
