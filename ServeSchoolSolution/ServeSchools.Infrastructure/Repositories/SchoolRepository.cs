using Microsoft.EntityFrameworkCore;
using ServeSchools.Domain.Common;
using ServeSchools.Domain.Repositories;
using ServeSchools.Domain.Schools;
using ServeSchools.Infrastructure.Data.DbContexts;

namespace ServeSchools.Infrastructure.Repositories
{
    public class SchoolRepository : GenericRepository<School>, ISchoolRepository
    {
        private readonly ApplicationDbContext context;

        public SchoolRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<School> CreateAsync(School entity)
        {
            try
            {
                context.Schools.Add(entity);
                int createTransaction = await context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteAsync(School entity)
        {
            try
            {
                // assign new properties
                entity.IsDeleted = true;
                context.Entry(entity).State = EntityState.Modified;
                int updateTransaction = context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<School>> GetAllAsync()
        {
            try
            {
                List<School> schools = await context.Schools.Where(x => !x.IsDeleted).ToListAsync();
                return schools;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<School?> GetByIdAsync(int? Id)
        {
            try
            {
                School? school = await context.Schools.Where(x => x.Id == Id && !x.IsDeleted).SingleOrDefaultAsync();
                return school;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void Update(School entity)
        {
            try
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
