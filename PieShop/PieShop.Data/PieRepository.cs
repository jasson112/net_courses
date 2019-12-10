using Microsoft.EntityFrameworkCore;
using PieShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PieShop.Data
{
    public class PieRepository : IPieRepository
    {
        private readonly PieShopDbContext pieShopDbContext;

        public PieRepository(PieShopDbContext pieShopDbContext)
        {
            this.pieShopDbContext = pieShopDbContext;
        }
        public IEnumerable<Pie> AllPies {
            get {
                return this.pieShopDbContext.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek {
            get {
                return this.pieShopDbContext.Pies.Include(c => c.Category).Where(p => p.OfTheWeek);
            }
        }

        public Pie GetPieById(int id)
        {
            return this.pieShopDbContext.Pies.FirstOrDefault(p => p.id == id);
        }
    }
}
