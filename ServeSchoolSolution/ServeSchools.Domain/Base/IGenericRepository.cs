namespace ServeSchools.Domain.Base
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Create(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
