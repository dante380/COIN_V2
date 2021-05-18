using AutoMapper;
using FavoursShop.Core;
using FavoursShop.Core.Models;
using FavoursShop.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FavoursShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IFavourRepository, FavourRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IShoppingCartService>(sp => ShoppingCartService.GetCart(sp));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<FavourShopDbContext>(ctx =>
            {
                ctx.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddAutoMapper();

            services.AddMemoryCache();

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                options.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<FavourShopDbContext>();

            //services.AddSession();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/UnAuthorized";
            });

        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseStatusCodePages();
            //app.UseSession();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {

                //routes.MapRoute(
                //    name: "categoryFilter",
                //    template: "Favours/{action}/{category?}",
                //    defaults: new { Controller = "Favour", action = "List" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
