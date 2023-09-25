using EmployeeManagementApi.Models;
using EmployeeManagementApi.Models.DTO;
using EmployeeManagementModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepo employeeRepo;
        public EmployeesController(IEmployeeRepo employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()
        {
            try
            {
                return Ok(await employeeRepo.GetAllEmployees());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployee([FromBody] AddEmployeeDto addEmployeeDto)
        {
            var employeeDomainModel = new Employee
            {
                FirstName = addEmployeeDto.FirstName,
                LastName = addEmployeeDto.LastName,
                Email = addEmployeeDto.Email,
                Gender = addEmployeeDto.Gender,
                DateOfBirth = addEmployeeDto.DateOfBirth,
                DepartmentId = addEmployeeDto.DepartmentId,
                PhotoPath = addEmployeeDto.PhotoPath,
            };

            try
            {
                employeeDomainModel = await employeeRepo.AddEmployee(employeeDomainModel);

                var employeeDto = new EmployeeDto
                {
                    EmployeeId = employeeDomainModel.EmployeeId,
                    FirstName = employeeDomainModel.FirstName,
                    LastName = employeeDomainModel.LastName,
                    Email = employeeDomainModel.Email,
                    Gender = employeeDomainModel.Gender,
                    DateOfBirth = employeeDomainModel.DateOfBirth,
                    DepartmentId = employeeDomainModel.DepartmentId,
                    PhotoPath = employeeDomainModel.PhotoPath,
                };

                return Ok(employeeDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating employee");
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult> GetEmployeeById([FromRoute] int id)
        {
            var employeeDomainModel = await employeeRepo.GetEmployeeById(id);
            return Ok(employeeDomainModel);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> UpdateEmployee([FromBody] EmployeeDto employee, [FromRoute] int id)
        {
            var employeeDomainModel = new Employee
            {
                EmployeeId = id,
                FirstName = employee.FirstName,
                Gender = employee.Gender,
                DateOfBirth = employee.DateOfBirth,
                DepartmentId = employee.DepartmentId,
                Email = employee.Email,
                LastName = employee.LastName,
                PhotoPath = employee.PhotoPath,
            };

            employeeDomainModel = await employeeRepo.UpdateEmployee(employeeDomainModel);

            if (employeeDomainModel == null)
            {
                return NotFound();
            }

            return Ok(employeeDomainModel);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteEmployee([FromRoute] int id)
        {
            var employeeToDelete = await employeeRepo.GetEmployeeById(id);

            if (employeeToDelete == null)
            {
                return NotFound();
            }

            var result = await employeeRepo.DeleteEmployee(employeeToDelete);

            return Ok(result);
        }
    }
}
