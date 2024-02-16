using ServeSchools.Application.DTOs;
using ServeSchools.Domain.Schools;

namespace ServeSchools.WebApi.Services
{
    public interface ISchoolService
    {
        public Task<List<School>> GetAllSchoolsAsync();
        public Task<School?> GetSchoolAsync(int? Id);
        public Task<int> AddSchoolAsync(CreateSchoolDTO? createRequest);
        public Task<int> EditSchoolAsync(UpdateSchoolDTO? updateRequest);
        public Task<int> SoftDeleteSchoolAsync(int? Id);
    }
}
