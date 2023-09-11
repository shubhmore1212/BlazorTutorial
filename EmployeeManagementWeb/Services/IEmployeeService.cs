using EmployeeManagementModels;

namespace EmployeeManagementWeb.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployee();
        Task<Employee> GetEmployeeById(int id);
    }
}
