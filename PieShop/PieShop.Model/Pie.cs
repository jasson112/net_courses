using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Model
{
    public class Pie
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string AllegryInfo { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
        public string ImgThumbUrl { get; set; }
        public bool OfTheWeek { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Notes { get; set; }
    }
}
