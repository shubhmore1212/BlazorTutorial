using EmployeeManagementApi.Models.DTO;
using EmployeeManagementModels;

namespace EmployeeManagementApi.Models
{
    public interface IEmployeeRepo
    {
        //for the method to be async
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee> DeleteEmployee(Employee employee);
    }
}
