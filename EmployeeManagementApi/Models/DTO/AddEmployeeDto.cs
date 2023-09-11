using EmployeeManagementModels;

namespace EmployeeManagementApi.Models.DTO
{
    public class AddEmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
    }
}
