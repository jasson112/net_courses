using PieShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PieShop.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PieShopDbContext pieShopDbContext;

        public CategoryRepository(PieShopDbContext pieShopDbContext)
        {
            this.pieShopDbContext = pieShopDbContext;
        }
        public IEnumerable<Category> AllCategories {
            get {
                return pieShopDbContext.Categories;
            }
        }

        public Category GetCategoryById(int id)
        {
            return pieShopDbContext.Categories.FirstOrDefault(p => p.id == id);
        }
    }
}
