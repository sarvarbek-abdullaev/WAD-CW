using API.Interfaces;
using API.Repositories;
using System.Threading.Tasks;

namespace API.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductContext dc;
        public UnitOfWork(ProductContext dc)
        {
            this.dc = dc;
        }

        public ICategoryRepository CategoryRepository => new CategoryRepository(dc);

        public IProductRepository ProductRepository => new ProductRepository(dc);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}
