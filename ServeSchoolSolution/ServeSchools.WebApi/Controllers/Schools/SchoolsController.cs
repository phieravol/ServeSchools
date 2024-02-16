using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServeSchools.Application.DTOs;
using ServeSchools.Application.UnitOfWorks;
using ServeSchools.Domain.Common;
using ServeSchools.Domain.Repositories;
using ServeSchools.Domain.Schools;

namespace ServeSchools.WebApi.Controllers.Schools
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<School> genericRepository;
        private readonly ISchoolRepository schoolRepository;
        private readonly IMapper mapper;

        public SchoolsController(
            IUnitOfWork unitOfWork, 
            IGenericRepository<School> genericRepository, 
            ISchoolRepository schoolRepository, 
            IMapper mapper
        ) {
            this.unitOfWork = unitOfWork;
            this.genericRepository = genericRepository;
            this.schoolRepository = schoolRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSchools()
        {
            try
            {
                List<School> schools = await unitOfWork.SchoolRepository.GetAllAsync();
                return Ok(schools);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetSchool(int? Id)
        {
            try
            {
                if (Id is null)
                {
                    throw new Exception("Please select a school!");
                }
                    
                School? school = await unitOfWork.SchoolRepository.GetByIdAsync(Id);
                if (school is null)
                {
                    throw new Exception("School not found!");
                }
                return Ok(school);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSchools([FromBody] CreateSchoolDTO? createRequest)
        {
            try
            {
                if (createRequest is null)
                {
                    return BadRequest("your update request not found!");
                }
                // convert to School
                School school = mapper.Map<School>(createRequest);
                // create school
                school = await unitOfWork.SchoolRepository.CreateAsync(school);
                int countTrans = await unitOfWork.SaveChangeAsync();
                if (countTrans < 0)
                {
                    throw new Exception("Some error occur while saving in database!");
                }
                return Ok("Create school succesfully!");
            }
            catch (Exception ex)
            {
                var errorObjectResult = new ObjectResult(ex.Message);
                errorObjectResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObjectResult;
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSchool([FromBody] UpdateSchoolDTO? updateRequest)
        {
            try
            {
                if (updateRequest is null)
                {
                    throw new Exception("Please enter information to update!");
                }
                // convert to school
                School school = mapper.Map<School>(updateRequest);
                School? newSchool = await genericRepository.GetByIdAsync(school.Id);

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
                return Ok("Update school successfully!");
            }
            catch (Exception ex)
            {
                var errorObjectResult = new ObjectResult(ex.Message);
                errorObjectResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObjectResult;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSchool(int? Id)
        {
            try
            {
                if (Id is null)
                {
                    throw new Exception("Please select school to update!");
                }
                School? school = await unitOfWork.SchoolRepository.GetByIdAsync(Id);
                if (school is null)
                {
                    throw new Exception("School not found!");
                }
                await unitOfWork.SchoolRepository.SoftDeleteAsync(school);
                int countTrans = await unitOfWork.SaveChangeAsync();
                if (countTrans <= 0)
                {
                    throw new Exception("Some error occur while saving in database!");
                }
                return Ok("Delete school successfully!");
            }
            catch (Exception ex)
            {
                var errorObjectResult = new ObjectResult(ex.Message);
                errorObjectResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObjectResult;
            }
        }
    }
}
