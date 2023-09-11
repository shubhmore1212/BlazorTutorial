using EmployeeManagementModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Department Table
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 2, DepartmentName = "HR" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 3, DepartmentName = "Payroll" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 4, DepartmentName = "Admin" });

            //Seed Employee Table
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Dipak",
                    LastName = "Naik",
                    Email = "diapk@gmail.com",
                    DateOfBirth = new DateTime(1980, 10, 5),
                    Gender = Gender.Male,
                    DepartmentId = 1,
                    PhotoPath = "images/john.jpg"
                }
                );

            modelBuilder.Entity<Employee>().HasData(
               new Employee
               {
                   EmployeeId = 2,
                   FirstName = "Akshay",
                   LastName = "K",
                   Email = "akshay@gmail.com",
                   DateOfBirth = new DateTime(1990, 10, 15),
                   Gender = Gender.Male,
                   DepartmentId = 2,
                   PhotoPath = "images/manny.jfif"
               }
               );


            modelBuilder.Entity<Employee>().HasData(
               new Employee
                 {
                   EmployeeId = 3,
                   FirstName = "Amy",
                   LastName = "F",
                   Email = "amy@gmail.com",
                   DateOfBirth = new DateTime(1999, 10, 1),
                   Gender = Gender.Female,
                   DepartmentId = 1,
                   PhotoPath = "images/manny.jfif"
               }
               );

            modelBuilder.Entity<Employee>().HasData(
             new Employee
             {
                 EmployeeId = 4,
                 FirstName = "John",
                 LastName = "Y",
                 Email = "john@gmail.com",
                 DateOfBirth = new DateTime(1980, 1, 5),
                 Gender = Gender.Male,
                 DepartmentId = 1,
                 PhotoPath = "images/james.jfif"
             }
             );
        }
    }
}
