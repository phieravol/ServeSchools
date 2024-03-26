namespace ServeSchools.Domain.Common
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync<T>(int? Id) where T : class, IEntityBase<int>, ISoftDeletable;
        Task<List<T>> GetAllAsync<T>() where T : class, ISoftDeletable;
        Task<T> CreateAsync(T entity);
        Task SoftDeleteAsync<T>(T entity) where T : class, ISoftDeletable;
        void Update(T entity);
    }
}
