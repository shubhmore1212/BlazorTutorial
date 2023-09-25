using CommonLibrary;
using EmployeeManagementModels;
using EmployeeManagementWeb.Services;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.Contracts;

namespace EmployeeManagementWeb.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; }

        public int SelectedEmployeesCount { get; set; } = 0;

        [Parameter]
        public EventCallback<bool> OnEmployeeSelection { get; set; }


        [Parameter]
        public EventCallback<int> OnEmployeeDeleted { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        protected ConfirmModalBase DeleteConfirmation { get; set; }

        public async Task CheckBoxChanged(ChangeEventArgs e)
        {
           await OnEmployeeSelection.InvokeAsync((bool)e.Value);
        }

        public void Delete_Click()
        {
            DeleteConfirmation.Show();
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await EmployeeService.DeleteEmployeeById(Employee.EmployeeId);
                await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
            }
        }

        //public async void Delete_Click()
        //{
        //    await EmployeeService.DeleteEmployeeById(Employee.EmployeeId);
        //    await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
        //}
    }
}
