using CartService.Contracts;
using CartService.Data;
using CartService.Models;

namespace CartService.Repositories
{
    public class ProductTwinRepository : GenericRepository<ProductTwin>, IProductTwinRepository
    {
        public ProductTwinRepository(DatabaseContext context): base(context)
        {

        }
    }
}
