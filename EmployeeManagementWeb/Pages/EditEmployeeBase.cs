using EmployeeManagementModels;
using EmployeeManagementWeb.Services;
using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;

namespace EmployeeManagementWeb.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        public Employee Employee { get; set; } =new Employee();

        public List<Department> Departments { get; set; } = new List<Department>();

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployeeById(int.Parse(Id));
            Departments = (await DepartmentService.GetAllDepartments()).ToList();
        }
    }
}
