using Microsoft.EntityFrameworkCore;
using ShopDb.Models;
using System.Collections.Generic;

namespace ShopDb
{
    public class MyDbContext : DbContext
    {
        public DbSet<Product> ProductDb { get; set; }
        public DbSet<User> UserDb { get; set; }

        public DbSet<Cart> CartDb { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Favourit> FavouritItems { get; set; }
        public DbSet<Compare> CompareItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
               new Product(1,"Xtrfy Retro Edition", "Ультра-легкая конструкция Уникальный, праворукий дизайн Сенсор pixart 3389 Провод xtrfy ezcord", 6999, "~/images/products/XtrfyRetro.webp"),
                new Product(2,"Logitech G G403 Hero", "В игровой мыши Logitech G403 HERO используется новейший датчик HERO 25K.Этот датчик обеспечивает отслеживание без задержек на скорости более 10 м/с (400 дюйм/с) при уровне чувствительности от 100 до 25 600 точек на дюйм.", 7999, "~/images/products/logitechG403.webp"),
                new Product(3,"Xtrfy Tokyo Edition", "Мышь проводная Xtrfy M4 RGB Tokyo отличается от многих моделей облегченным перфорированным корпусом. Слегка изогнутый корпус удобно лежит в правой руке, снимая лишнее напряжение с запястья.", 8999, "~/images/products/XtrfyTokyoEdition.webp"),
                new Product(4,"Steelseries Rival 3", "Мышь проводная SteelSeries Rival 3 - оптимальный вариант для прохождения игр любой жанровой направленности.", 4090, "~/images/products/SteelseriesRival3.webp"),
                new Product(5,"Steelseries Sensei", "Дизайн и габариты SteelSeries Sensei очень напоминают легендарную мышь SteelSeries Xai Laser, которая может похвастать отличной эргономикой. Корпус имеет симметричную форму, и поэтому манипулятор подходит как правшам, так и левшам.", 6060 , "~/images/products/SteelseriesSensei.webp"),
                new Product(6,"Steelseries Apex", "Игровая клавиатура SteelSeries Apex 5 Keyboard RU чёрная Корпус SteelSeries Apex 5 — это монолитная пластина, изготовленная из авиационного алюминия Series 5000, который отличается исключительной прочностью и надежностью. ", 12990, "~/images/products/SteelseriesApex.webp"),
                new Product(7,"Logitech G Pro", "Клавиатура Logitech G Pro представлена в строгом черном корпусе и обладает многочисленными функциями, которые делают ее идеальным инструментом для игр. Это механическая клавиатура с переключателями GX Blue.", 10999, "~/images/products/LogitechGpro.webp"),
                new Product(8,"Logitech Pop keys", "Беспроводная клавиатура Logitech POP Keys. Круглые клавиши модели напоминают клавиши печатной машинки. Звук при печати довольно громкий и для срабатывания нужно сделать довольно сильное нажатие.", 8990 , "~/images/products/LogitechPopKeys.webp"),
                new Product(9,"Steelseries Qck edge", "Игровой коврик Steelseries QcK Edge M размерами 32х27 см отлично подходит для яростных виртуальных сражений. Стильный аксессуар легко сочетается с другими геймерскими комплектующими.", 2990, "~/images/products/SteelseriesQck.webp"),
                new Product(10,"Xtrfy Forest Edition", "Большой игровой коврик для мыши. Patrik \"F0REST\" Lindberg EDITION.", 3990 , "~/images/products/XtrfyForestEdition.webp")
            });
        }
    }
}
