using Library.DAL;
using Library.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.repositories
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
            Save();
        }
        public Category GetCategoryById(int Id)
        {
            var cate = _dbContext.Categories.Find(Id);
            return cate;
        }
        public IEnumerable<Category> GetGategory()
        {
            return _dbContext.Categories.ToList();
        }

        public void InsertCategory(Category category)
        {
            _dbContext.Add(category);
            Save();
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
