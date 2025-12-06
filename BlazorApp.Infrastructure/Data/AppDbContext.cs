using BlazorApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = default!;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}