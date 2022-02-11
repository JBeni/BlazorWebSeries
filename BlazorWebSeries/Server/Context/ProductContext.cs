using BlazorWebSeries.Server.Context.Configuration;
using BlazorWebSeries.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebSeries.Server.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

        public DbSet<Product> Products { get; set; }
    }
}
