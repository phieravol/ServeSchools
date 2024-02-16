namespace ServeSchools.Domain.Common
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int? Id);
        Task<List<T>> GetAllAsync();
        Task<T> CreateAsync(T entity);
        Task SoftDeleteAsync<T>(T entity) where T : class, ISoftDeletable;
        void Update(T entity);
    }
}
