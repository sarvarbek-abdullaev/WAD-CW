using Library.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.repositories
{
    public interface ICategoryRepository
    {
        void InsertCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int categoryid);
        Category GetCategoryById(int Id);
        IEnumerable<Category> GetGategory();
    }
}
