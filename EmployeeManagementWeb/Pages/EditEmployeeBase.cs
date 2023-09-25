using AutoMapper;
using EmployeeManagementModels;
using EmployeeManagementWeb.Models;
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

        public Employee Employee { get; set; } = new Employee();

        public EditEmployeeModel EditEmployee { get; set; } = new EditEmployeeModel();

        public List<Department> Departments { get; set; } = new List<Department>();

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string Page_Header { get; set; }

        protected override async Task OnInitializedAsync()
        {
            int.TryParse(Id, out int employeeId);

            if (employeeId != 0)
            {
                Page_Header = "Edit Employee";
                Employee = await EmployeeService.GetEmployeeById(int.Parse(Id));
            }
            else
            {
                Page_Header = "Create Employee";
                Employee = new Employee
                {
                    DepartmentId = 1,
                    DateOfBirth = DateTime.Now,
                    PhotoPath = "images/john.jpg"
                };
            }

            Departments = (await DepartmentService.GetAllDepartments()).ToList();

            Mapper.Map(Employee, EditEmployee);
        }

        protected async Task HandleValidSubmit()
        {
            Mapper.Map(EditEmployee, Employee);

            Employee result = null;

            if (Employee.EmployeeId != 0)
            {
                result = await EmployeeService.UpdateEmployee(Employee);
            }
            else
            {
                result = await EmployeeService.CreateEmployee(Employee);
            }

            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }

        protected async Task HandleDeleteEmployee()
        {
            await EmployeeService.DeleteEmployeeById(Employee.EmployeeId);
            NavigationManager.NavigateTo("/");
        }
    }
}
