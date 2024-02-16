using ServeSchools.Domain.Common;
using ServeSchools.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServeSchools.Application.UnitOfWorks
{
    public interface IUnitOfWork: IDisposable
    {
        ISchoolRepository SchoolRepository { get; }
        Task<int> SaveChangeAsync();
    }
}
