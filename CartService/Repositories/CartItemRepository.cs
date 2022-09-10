using CartService.Contracts;
using CartService.Data;
using CartService.Models;

namespace CartService.Repositories
{
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }
    }
}
