using PieShop.Model;
using System.Collections.Generic;
using System.Linq;

namespace PieShop.Data
{
    public class MockCategoryRepository : ICategoryRepository
    {
        List<Category> categories;
        public MockCategoryRepository()
        {
            categories = new List<Category> {
                new Category { id = 1, Name = "Fruit Pies", Description = "All pies with fruit" },
                new Category { id = 2, Name = "Cheese Cakes", Description = "Cheese Cheeeeeeseeee !" },
                new Category { id = 3, Name = "Seasonal Pies", Description = "Get the mood of the seasons" }
            };
        }
        public IEnumerable<Category> AllCategories => from c in categories orderby c.Name select c;

        public Category GetCategoryById(int id)
        {
            return this.categories.SingleOrDefault(c => c.id == id);
        }
    }
}
