using EmployeeManagementModels;
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

        public async Task CheckBoxChanged(ChangeEventArgs e)
        {
           await OnEmployeeSelection.InvokeAsync((bool)e.Value);
        }
    }
}
