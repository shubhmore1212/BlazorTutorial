using EmployeeManagementApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepo departmentRepo;
        public DepartmentController(IDepartmentRepo departmentRepo)
        {
            this.departmentRepo = departmentRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllDepartments()
        {
            try
            {
                var deparmentModels = await departmentRepo.GetAllDepartments();
                return Ok(deparmentModels);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "error retrieving data from database");
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult> GetDepartmentById([FromRoute] int id)
        {
            try
            {
                var deparmentModel = await departmentRepo.GetDepartmentById(id);
                if(deparmentModel == null)
                {
                    return NotFound();
                }
                return Ok(deparmentModel);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "error retrieving data from database");
            }
        }

    }
}
