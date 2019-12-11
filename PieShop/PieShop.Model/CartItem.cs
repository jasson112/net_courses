using System;
using System.Collections.Generic;
using System.Text;

namespace PieShop.Model
{
    public class CartItem
    {
        public int id { get; set; }
        public Pie Pie { get; set; }
        public int Amount { get; set; }
        public string CartId { get; set; }
    }
}
