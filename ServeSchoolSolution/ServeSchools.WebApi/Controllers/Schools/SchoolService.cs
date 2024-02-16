using AutoMapper;
using ServeSchools.Application.DTOs;
using ServeSchools.Application.UnitOfWorks;
using ServeSchools.Domain.Common;
using ServeSchools.Domain.Schools;
using ServeSchools.WebApi.Services;

namespace ServeSchools.WebApi.Controllers.Schools
{
    public class SchoolService : ISchoolService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<School> genericRepository;
        private readonly IMapper mapper;

        public SchoolService(IUnitOfWork unitOfWork, IGenericRepository<School> genericRepository, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.genericRepository = genericRepository;
            this.mapper = mapper;
        }

        public async Task<int> AddSchoolAsync(CreateSchoolDTO? createRequest)
        {
            try
            {
                // validate request
                if (createRequest is null)
                {
                    throw new Exception("your update request not found!");
                }
                // convert to School
                School school = mapper.Map<School>(createRequest);
                // create school
                school = await genericRepository.CreateAsync(school);
                // return transaction executed
                int countTrans = await unitOfWork.SaveChangeAsync();
                if (countTrans < 0)
                {
                    throw new Exception("Some error occur while saving in database!");
                }
                return countTrans;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> EditSchoolAsync(UpdateSchoolDTO? updateRequest)
        {
            try
            {
                if (updateRequest is null)
                {
                    throw new Exception("Please enter information to update!");
                }
                // convert to school
                School school = mapper.Map<School>(updateRequest);
                School? newSchool = await genericRepository.GetByIdAsync<School>(school.Id);

                if (newSchool is null)
                {
                    throw new Exception("School not found!");
                }
                newSchool.Name = updateRequest.Name;
                newSchool.FoundingDate = updateRequest.FoundingDate;
                newSchool.LastUpdated = DateTime.UtcNow;

                genericRepository.Update(newSchool);
                int countTrans = await unitOfWork.SaveChangeAsync();
                if (countTrans < 0)
                {
                    throw new Exception("Some error occur while saving in database!");
                }
                return countTrans;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<School>> GetAllSchoolsAsync()
        {
            List<School> schools = await genericRepository.GetAllAsync<School>();
            return schools;
        }

        public async Task<School?> GetSchoolAsync(int? Id)
        {
            try
            {
                if (Id is null)
                {
                    throw new Exception("Please select a school!");
                }

                School? school = await genericRepository.GetByIdAsync<School>(Id);
                if (school is null)
                {
                    throw new Exception("School not found!");
                }
                return school;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<int> SoftDeleteSchoolAsync(int? Id)
        {
            try
            {
                if (Id is null)
                {
                    throw new Exception("Please select school to update!");
                }
                School? school = await genericRepository.GetByIdAsync<School>(Id);
                if (school is null)
                {
                    throw new Exception("School not found!");
                }
                await genericRepository.SoftDeleteAsync<School>(school);
                int countTrans = await unitOfWork.SaveChangeAsync();
                if (countTrans <= 0)
                {
                    throw new Exception("Some error occur while saving in database!");
                }
                return countTrans;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
