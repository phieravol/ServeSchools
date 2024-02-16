using Microsoft.AspNetCore.Mvc;
using ServeSchools.Application.DTOs;
using ServeSchools.Domain.Schools;
using ServeSchools.WebApi.Services;

namespace ServeSchools.WebApi.Controllers.Schools
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly ISchoolService schoolService;
        public SchoolsController(
            ISchoolService schoolService
        ) {
            this.schoolService = schoolService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSchools()
        {
            try
            {
                List<School> schools = await schoolService.GetAllSchoolsAsync();
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
                School? school = await schoolService.GetSchoolAsync(Id);
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
                await schoolService.AddSchoolAsync(createRequest);
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
                await schoolService.EditSchoolAsync(updateRequest);
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
        public async Task<IActionResult> RemoveSchool(int? Id)
        {
            try
            {
                await schoolService.SoftDeleteSchoolAsync(Id);
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
