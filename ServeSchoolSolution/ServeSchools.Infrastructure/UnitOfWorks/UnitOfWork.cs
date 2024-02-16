using Microsoft.EntityFrameworkCore;
using ServeSchools.Domain.Repositories;
using ServeSchools.Infrastructure.Data.DbContexts;
using ServeSchools.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServeSchools.Application.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        private ISchoolRepository schoolRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ISchoolRepository SchoolRepository => schoolRepository ??= new SchoolRepository(context);

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<int> SaveChangeAsync()
        {
            try
            {
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
