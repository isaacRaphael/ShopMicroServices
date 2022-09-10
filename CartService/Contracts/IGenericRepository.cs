namespace CartService.Contracts
{
    public interface IGenericRepository<T>
    {
        Task<T> Add(T entity);
        Task<T> GetById(Guid id);
    }
}
