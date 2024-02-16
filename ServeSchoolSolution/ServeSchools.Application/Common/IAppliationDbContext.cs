using Microsoft.EntityFrameworkCore;
using ServeSchools.Domain.Schools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServeSchools.Application.Common
{
    public interface IAppliationDbContext
    {
        public DbSet<School> Schools { get; set; }

    }
}
