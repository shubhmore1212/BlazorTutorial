using EmployeeManagementModels;
using System.Text;
using System.Text.Json;
using System.Net.Http;

namespace EmployeeManagementWeb.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;
        
        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Employee> CreateEmployee(Employee newEmployee)
        {
            var company = JsonSerializer.Serialize(newEmployee);
            var requestContent = new StringContent(company, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/Employees", requestContent);
            var content = await response.Content.ReadAsStringAsync();
            var createdEmp = JsonSerializer.Deserialize<Employee>(content);
            return createdEmp;
        }

        public async Task DeleteEmployeeById(int id)
        {
            await httpClient.DeleteAsync($"api/Employees/{id}");
        }

        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            return await httpClient.GetFromJsonAsync<Employee[]>("api/Employees");
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await httpClient.GetFromJsonAsync<Employee>($"api/Employees/{id}");
        }

        public async Task<Employee> UpdateEmployee(Employee updatedEmployee)
        {
            var employee = JsonSerializer.Serialize(updatedEmployee);
            var requestContent = new StringContent(employee, Encoding.UTF8, "application/json");
            var response=await httpClient.PutAsync($"api/Employees/{updatedEmployee.EmployeeId}",requestContent);
            var content=await response.Content.ReadAsStringAsync();
            var updatedEmp= JsonSerializer.Deserialize<Employee>(content);
            return updatedEmp;
        }
    }
}
