using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BlazorApp.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // 🔥 Use SAME CONNECTION STRING you have in appsettings.json
            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5432;Database=BlazorDb;Username=postgres;Password=your_strong_password");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
