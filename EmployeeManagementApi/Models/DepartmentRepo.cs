using EmployeeManagementModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementApi.Models
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly AppDbContext appDbContext;

        public DepartmentRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await appDbContext.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentById(int departmentId)
        {
            return await appDbContext.Departments
                .FirstOrDefaultAsync(dep => dep.DepartmentId == departmentId);
        }
    }
}
