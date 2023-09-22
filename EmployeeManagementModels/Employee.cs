using EmployeeManagementModels.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementModels
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage ="First Name is required field")]
        [MinLength(2)]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [EmailDomainValidator]
        public string Email { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int DepartmentId { get; set; }

        public string PhotoPath { get; set; }

        public Department Department { get; set; }
    }
}
