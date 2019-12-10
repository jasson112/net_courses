using PieShop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PieShop.Data
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
        Category GetCategoryById(int id);
    }
}
