using EmployeeManagementModels;

namespace EmployeeManagementWeb.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient httpClient;
        public DepartmentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await httpClient.GetFromJsonAsync<Department[]>("api/department");
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await httpClient.GetFromJsonAsync<Department>($"api/department/${id}");
        }
    }
}
