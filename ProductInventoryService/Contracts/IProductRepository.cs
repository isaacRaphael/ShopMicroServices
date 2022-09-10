using ProductInventoryService.Models;

namespace ProductInventoryService.Contracts
{
    public interface IProductRepository
    {
        Task<Product> Add(Product product);
    }
}
