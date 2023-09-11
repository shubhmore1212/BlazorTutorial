using EmployeeManagementModels;

namespace EmployeeManagementWeb.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;
        
        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            return await httpClient.GetFromJsonAsync<Employee[]>("api/Employees");
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await httpClient.GetFromJsonAsync<Employee>($"api/Employees/{id}");
        }
    }
}
