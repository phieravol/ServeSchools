using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServeSchools.Application.Common;
using ServeSchools.Domain.Schools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServeSchools.Infrastructure.Data.DbContexts
{
    public class ApplicationDbContext : DbContext, IAppliationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();
                string? ConnectionString = configuration.GetConnectionString("ServeSchoolConnection");
                optionsBuilder.UseNpgsql(ConnectionString);
            }
        }
        public DbSet<School> Schools { get; set; }
    }
}
