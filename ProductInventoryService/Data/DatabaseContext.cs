using Microsoft.EntityFrameworkCore;
using ProductInventoryService.Models;

namespace ProductInventoryService.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options ): base(options)
        {

        }

        public DbSet<Product>? Products { get; set; }
    }
}
