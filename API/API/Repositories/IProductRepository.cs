using API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Repositories
{
    public interface IProductRepository
    {
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productid);
        Product GetProductById(int Id);
        Task<IEnumerable<Product>> GetProducts();
    }
}
