using FavoursShop.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FavoursShop.Persistence
{
    public class FavourShopDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Favour> Favours { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        public FavourShopDbContext(DbContextOptions<FavourShopDbContext> options)
            : base(options)
        {

        }
    }
}
