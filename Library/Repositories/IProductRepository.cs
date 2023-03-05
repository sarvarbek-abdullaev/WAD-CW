using Library.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.repositories
{
    public interface IProductRepository
    {
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productid);
        Product GetProductById(int Id);
        IEnumerable<Product> GetProducts();
    }
}
