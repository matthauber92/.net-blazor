using BlazorApp.Domain.Repositories;
using BlazorApp.Domain;
using BlazorApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllByAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        // EF Core tracks changes automatically, so the update method often just attaches/marks for complex scenarios,
        // but for a tracked entity, it may be empty, or just ensure tracking:
        //public void Update(Product product)
        //{
        //    _context.Entry(product).State = EntityState.Modified;
        //}

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }

        // Unit of Work Implementation: The single method to commit all changes in a transaction
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}