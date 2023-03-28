using API.DAL;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductContext _dbContext;
        public CategoryRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteCategory(int categoryid)
        {
            var category = _dbContext.Categories.Find(categoryid);
            _dbContext.Categories.Remove(category);
        }
        public Category GetCategoryById(int Id)
        {
            var cate = _dbContext.Categories.Find(Id);
            return cate;
        }
        public async Task<IEnumerable<Category>> GetCategory()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public void InsertCategory(Category category)
        {
            _dbContext.Add(category);
        }

        public void UpdateCategory(Category category)
        {
            _dbContext.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
