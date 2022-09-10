using ProductInventoryService.Contracts;
using ProductInventoryService.Data;
using ProductInventoryService.Models;

namespace ProductInventoryService.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _context;

        public ProductRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Product> Add(Product product)
        {
            await _context.Set<Product>().AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
