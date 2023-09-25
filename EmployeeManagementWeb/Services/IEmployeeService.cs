using EmployeeManagementModels;

namespace EmployeeManagementWeb.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployee();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> UpdateEmployee(Employee updatedEmployee);
        Task<Employee> CreateEmployee(Employee newEmployee);
        Task DeleteEmployeeById(int id);
    }
}
