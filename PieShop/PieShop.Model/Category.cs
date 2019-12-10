using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Model
{
    public class Category
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Pie> Pies { get; set; }
    }
}
