using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShopDb;
using ShopDb.Interfaces;
using Serilog;
using OnlineShopWebApp.Interfaces;
using ShopDb.Storages;

namespace OnlineShopWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Log.Logger = new LoggerConfiguration()
            .WriteTo.File("logs.txt", rollOnFileSizeLimit: true, fileSizeLimitBytes: 1048576)
            .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICartStorage, CartStorage>();
            services.AddTransient<IProductStorage, ProductStorage>();
            services.AddTransient<IOrderStorage, OrderStorage>();
            services.AddTransient<ICompareStorage, CompareStorage>();
            services.AddTransient<IFavouritesStorage, FavouritesStorage>();
            services.AddTransient<IUserStorage, UserStorage>();
            //services.AddTransient<IRolesStorage, RolesStorage>();
            services.AddControllersWithViews();
            services.AddDbContext<MyDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddSerilog();
            });
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger, MyDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "MyArea",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
