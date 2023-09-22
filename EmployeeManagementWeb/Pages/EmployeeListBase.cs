using EmployeeManagementModels;
using EmployeeManagementWeb.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagementWeb.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        public bool ShowFooter { get; set; } = true;

        protected int SelectedEmployeesCount { get; set; } = 0;

        protected void EmployeeSelectionChanged(bool isSelected)
        {
            if (isSelected)
            {
                SelectedEmployeesCount++;
            }
            else
            {
                SelectedEmployeesCount--;
            }
        }

        protected async Task EmployeeDeleted()
        {
            Employees = (await EmployeeService.GetEmployee()).ToList();
        }

        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeService.GetEmployee()).ToList();
        }

        //private void LoadEmployees()
        //{
        //    System.Threading.Thread.Sleep(3000);

        //    Employee e1 = new Employee
        //    {
        //        EmployeeId = 1,
        //        FirstName = "Dipak",
        //        LastName = "Naik",
        //        Email = "diapk@gmail.com",
        //        DateOfBirth = new DateTime(1980, 10, 5),
        //        Gender = Gender.Male,
        //        DepartmentId = 1,
        //        PhotoPath = "images/john.jpg"
        //    };

        //    Employee e2 = new Employee
        //    {
        //        EmployeeId = 1,
        //        FirstName = "Akshay",
        //        LastName = "K",
        //        Email = "akshay@gmail.com",
        //        DateOfBirth = new DateTime(1990, 10, 15),
        //        Gender = Gender.Male,
        //        DepartmentId = 2,
        //        PhotoPath = "images/manny.jfif"
        //    };

        //    Employee e3 = new Employee
        //    {
        //        EmployeeId = 1,
        //        FirstName = "Amy",
        //        LastName = "F",
        //        Email = "amy@gmail.com",
        //        DateOfBirth = new DateTime(1999, 10, 1),
        //        Gender = Gender.Female,
        //        DepartmentId = 1,
        //        PhotoPath = "images/manny.jfif"
        //    };

        //    Employee e4 = new Employee
        //    {
        //        EmployeeId = 1,
        //        FirstName = "John",
        //        LastName = "Y",
        //        Email = "john@gmail.com",
        //        DateOfBirth = new DateTime(1980, 1, 5),
        //        Gender = Gender.Male,
        //        DepartmentId = 1,
        //        PhotoPath = "images/james.jfif"
        //    };

        //    Employees = new List<Employee> { e1, e2, e3, e4 };
        //}
    }
}
