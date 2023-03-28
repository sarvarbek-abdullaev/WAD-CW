using API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface ICategoryRepository
    {
        void InsertCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int categoryid);
        Category GetCategoryById(int Id);
        Task<IEnumerable<Category>> GetCategory();
    }
}
