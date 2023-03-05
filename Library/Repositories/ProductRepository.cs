using Library.DAL;
using Library.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly ProductContext _dbContext;
        public ProductRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteProduct(int productId)
        {
            var product = _dbContext.Products.Find(productId);
            _dbContext.Products.Remove(product);
            Save();
        }
        public Product GetProductById(int productId)
        {
            var prod = _dbContext.Products.Find(productId);
            //_dbContext.Entry(prod).Reference(s => s.ProductCategory).Load();
            return prod;
        }
        public IEnumerable<Product> GetProducts()
        {

            return _dbContext.Products.ToList();
            //.Include(s => s.ProductCategory).ToList();
        }
        public void InsertProduct(Product product)
        {

            product.ProductCategory = _dbContext.Categories.Find(product.ProductCategory.ID);
            _dbContext.Add(product);
            Save();
        }
        public void UpdateProduct(Product product)
        {
            _dbContext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }


    }
}
