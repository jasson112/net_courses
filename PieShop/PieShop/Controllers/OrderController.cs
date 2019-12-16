using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PieShop.Data;
using PieShop.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PieShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly CartRepository cartRepository;

        public OrderController(IOrderRepository orderRepository, CartRepository cartRepository)
        {
            this.orderRepository = orderRepository;
            this.cartRepository = cartRepository;
        }

        // GET: /<controller>/
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = cartRepository.GetCartItems();
            cartRepository.CartItems = items;

            if (cartRepository.CartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some pies first");
            }

            if (ModelState.IsValid)
            {
                orderRepository.CreateOrder(order);
                cartRepository.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. Yout'll soon enjoy our delicious pies";
            return View();
        } 
    }
}
