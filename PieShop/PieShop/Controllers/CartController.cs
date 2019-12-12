using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PieShop.Data;
using PieShop.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PieShop.Controllers
{
    public class CartController : Controller
    {
        private readonly IPieRepository pieRepository;
        private readonly CartRepository cartRepository;

        public CartController(IPieRepository pieRepository, CartRepository cartRepository)
        {
            this.pieRepository = pieRepository;
            this.cartRepository = cartRepository;
        }

        public ViewResult Index() {
            var items = cartRepository.GetCartItems();
            cartRepository.CartItems = items;

            var cartViewModel = new CartViewModel
            {
                Cart = cartRepository,
                CartTotal = cartRepository.GetCartTotal()
            };

            return View(cartViewModel);
        }

        public RedirectToActionResult AddToCart(int pieId)
        {
            var selectedPie = pieRepository.AllPies.FirstOrDefault(p => p.id == pieId);

            if (selectedPie != null)
            {
                cartRepository.AddToCart(selectedPie, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromCart(int pieId)
        {
            var selectedPie = pieRepository.AllPies.FirstOrDefault(p => p.id == pieId);

            if (selectedPie != null)
            {
                cartRepository.RemoveFromCart(selectedPie);
            }
            return RedirectToAction("Index");
        }
    }
}
