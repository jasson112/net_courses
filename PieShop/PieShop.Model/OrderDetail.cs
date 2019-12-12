using System;
using System.Collections.Generic;
using System.Text;

namespace PieShop.Model
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int OrderId { get; set; }
        public int PieId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Pie Pie { get; set; }
        public Order Order { get; set; }
    }
}
