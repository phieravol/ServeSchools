using Microsoft.EntityFrameworkCore;
using ServeSchools.Domain.Common;
using ServeSchools.Infrastructure.Data.DbContexts;

namespace ServeSchools.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await context.AddAsync(entity);
            return entity;
        }

        public async Task SoftDeleteAsync<T>(T entity) where T : class, ISoftDeletable
        {
            entity.IsDeleted = true;
            context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<List<T>> GetAllAsync<T>() where T : class, ISoftDeletable
        {
            List<T> result = await context.Set<T>().Where(x => !x.IsDeleted).ToListAsync();
            return result;
        }

        public async Task<T?> GetByIdAsync<T>(int? Id) where T : class, IEntityBase<int>, ISoftDeletable
        {
            T? result = await context.Set<T>().Where(x => x.Id == Id && !x.IsDeleted).FirstOrDefaultAsync();
            return result;
        }

        public void Update(T entity)
        {
            T? currentObject = context.Set<T>().FirstOrDefault();
            if (currentObject == null) { throw new Exception("Object not found!"); }
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
