using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace OnlineShop.Db
{
    public class MyDbContext : DbContext
    {
        public DbSet<ProductDb> ProductDb { get; set; }
        public DbSet<UserDb> UserDb { get; set; }

        public DbSet<CartDb> CartDb { get; set; }

        public DbSet<Orders> Orders { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDb>(entity =>
            {
                entity.ToTable("Products");
                //entity.HasKey(s => s.Id);
                entity.Property(s => s.Id).IsRequired();
                entity.Property(s => s.Name).IsRequired();
                entity.Property(s => s.Cost).IsRequired();
                entity.Property(s => s.Description).IsRequired();
            });

            modelBuilder.Entity<UserDb>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Name).IsRequired();
                entity.Property(s => s.Password).IsRequired();
            });

            modelBuilder.Entity<CartDb>(entity =>
            {
                entity.ToTable("Cart");
                entity.HasKey(s => s.UserId);
                //entity.Property(s => s.UserId).IsRequired();
                entity.Property(s => s.ProductName).IsRequired();
                entity.Property(s => s.ProductId).IsRequired();
                entity.Property(s => s.Cost).IsRequired();
                entity.Property(s => s.Quantity).IsRequired();
                entity.Property(s => s.ImagePath).IsRequired();
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("Orders");
                entity.HasKey(s => s.OrderId);
                entity.Property(s => s.UserId).IsRequired();
                entity.Property(s => s.CustomerName).IsRequired();
                entity.Property(s => s.ShippingAddress).IsRequired();
                entity.Property(s => s.ShippingAddress).IsRequired();
            });

        //    modelBuilder.Entity<CartDb>()
        //.Ignore(c => c.Product);
        //    modelBuilder.Entity<Orders>()
        //.Ignore(o => o.ProductList);

        }
    }
}
