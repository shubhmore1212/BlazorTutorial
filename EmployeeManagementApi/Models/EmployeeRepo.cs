﻿using EmployeeManagementApi.Models.DTO;
using EmployeeManagementModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementApi.Models
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly AppDbContext appDbContext;
        public EmployeeRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result= await appDbContext.Employees.AddAsync(employee);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteEmployeeById(int employeeId)
        {
            var result=await appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if (result != null)
            {
                appDbContext.Employees.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await appDbContext.Employees
                .Include(e=>e.Department)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await appDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result=await appDbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

            if(result != null)
            {
                result.FirstName=employee.FirstName;
                result.LastName = employee.LastName;
                result.Email=employee.Email;
                result.DateOfBirth = employee.DateOfBirth;
                result.Gender = employee.Gender;
                result.DepartmentId = employee.DepartmentId;
                result.PhotoPath = employee.PhotoPath;

                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
