using Microsoft.EntityFrameworkCore;
using ServeSchools.Domain.Common;
using ServeSchools.Infrastructure.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<List<T>> GetAllAsync()
        {
            List<T> result = await context.Set<T>().ToListAsync();
            return result;
        }

        public async Task<T?> GetByIdAsync(int? Id)
        {
            T? result = await context.Set<T>().FirstOrDefaultAsync();
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
