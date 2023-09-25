using EmployeeManagementModels;
using EmployeeManagementModels.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementWeb.Models
{
    public class EditEmployeeModel : Employee
    {
        [CompareProperty("Email",ErrorMessage = "Confirm Email should be same as Email")]
        public string ConfirmEmail { get; set; }

        [ValidateComplexType(ErrorMessage ="Department not present")]
        public Department Department { get; set; } = new Department();
    }
}
