using EmployeeManagementModels;

namespace EmployeeManagementApi.Models
{
    public interface IDepartmentRepo
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(int departmentId);
    }
}
