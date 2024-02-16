using ServeSchools.Domain.Base;
using ServeSchools.Domain.Schools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServeSchools.Application.Repositories
{
    public interface ISchoolRepository: IGenericRepository<School>
    {
    }
}
