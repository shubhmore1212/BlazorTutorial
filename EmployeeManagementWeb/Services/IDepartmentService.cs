using EmployeeManagementModels;

namespace EmployeeManagementWeb.Services
{
    public interface IDepartmentService
    {
        Task<Department> GetDepartmentById(int id);
        Task<IEnumerable<Department>> GetAllDepartments();
    }
}
