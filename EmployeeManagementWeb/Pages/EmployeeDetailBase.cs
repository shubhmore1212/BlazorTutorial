using EmployeeManagementModels;
using EmployeeManagementWeb.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace EmployeeManagementWeb.Pages
{
    public class EmployeeDetailBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee();
        public string Coordinates { get; set; }
        protected string ButtonText { get; set; } = "Hide Footer";
        protected string CssClass { get; set; } = null;

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Employee = await EmployeeService.GetEmployeeById(int.Parse(Id));
        }

        protected void Mouse_Move(MouseEventArgs args)
        {
            Coordinates = $"X = {args.ClientX}  Y = {args.ClientY}";
        }

        protected void Button_Click()
        {
            if(ButtonText == "Hide Footer")
            {
                ButtonText = "Show Footer";
                CssClass = "HideFooter";
            }
            else
            {
                ButtonText = "Hide Footer";
                CssClass = null;
            }
        }
    }
}
