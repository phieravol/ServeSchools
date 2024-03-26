using ServeSchools.Domain.Repositories;

namespace ServeSchools.Application.UnitOfWorks
{
    public interface IUnitOfWork: IDisposable
    {
        ISchoolRepository SchoolRepository { get; }
        Task<int> SaveChangeAsync();
    }
}
