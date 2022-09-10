using CartService.Contracts;
using CartService.Data;
using CartService.Models;

namespace CartService.Repositories
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(DatabaseContext context, ILogger<CartRepository> logger) : base(context)
        {

        }
    }
}
