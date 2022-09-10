using CartService.Models;
using Microsoft.EntityFrameworkCore;

namespace CartService.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Cart>? Carts { get; set; }
        public DbSet<ProductTwin>? Products { get; set; }
    }
}
