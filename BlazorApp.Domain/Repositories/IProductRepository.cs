
using System.Threading.Tasks;

namespace BlazorApp.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllByAsync();
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product product);
        //void Update(Product product);
        void Delete(Product product);
        Task<int> SaveChangesAsync();
    }
}