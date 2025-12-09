using BlazorApp.Domain;
using BlazorApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}