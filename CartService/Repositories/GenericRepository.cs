using CartService.Contracts;
using CartService.Data;
using CartService.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace CartService.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _table;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            _table.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> GetById(Guid id)
        {
            return await _table.Where(x => x.Id == id).SingleOrDefaultAsync();
        }
    }
}
