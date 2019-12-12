using PieShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.ViewModels
{
    public class CartViewModel
    {
        public CartRepository Cart { get; set; }
        public decimal CartTotal { get; set; }
    }
}
