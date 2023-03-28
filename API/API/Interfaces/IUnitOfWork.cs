using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        Task<bool> SaveAsync();
    }
}
