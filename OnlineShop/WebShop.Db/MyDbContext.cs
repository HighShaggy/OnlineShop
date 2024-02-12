using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using OnlineShopWebApp.Models.DbItems;
using System.Data.Entity;

namespace OnlineShop.Db
{
    public class MyDbContext : DbContext
    {
        public DbSet<ProductDb> ProductDbs { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDb>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Name).IsRequired();
                entity.Property(s => s.Cost).IsRequired();
                entity.Property(s => s.Description).IsRequired();
            });
        }
    }
}
