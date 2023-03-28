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
        void DeleteCategory(int categoryid);
        Task<Category> GetCategoryById(int Id);
        Task<IEnumerable<Category>> GetCategory();
        void UpdateCategory(Category category);
    }
}
