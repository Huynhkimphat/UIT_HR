using System;
using System.Collections.Generic;
using HR_UIT.Data;
using HR_UIT.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HR_UIT.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HrUitDbContext _db;

        public EmployeeService(HrUitDbContext dbContext)
        {
            _db = dbContext;
        }

        /// <summary>
        /// Return a list of Employees from database 
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllEmployees()
        {
            return _db
                .Employees
                .Include(employee => employee.PrimaryAddress)
                .Where(employee => !employee.IsArchived)
                // .Include(employee => employee.PrimaryAccount)
                // .Include(employee => employee.PrimaryDayOff)
                .OrderBy(employee => employee.Id)
                .ToList();
        }

        public ServiceResponse<Employee> CreateEmployee(Employee employee)
        {
            var now = DateTime.UtcNow;
            try
            {
                _db.Employees.Add(employee);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.Employee>
                {
                    Data = employee,
                    Time = now,
                    Message = "Saved new employee",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.Employee>
                {
                    Data = null,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

        public ServiceResponse<bool> DeleteEmployee(int id)
        {
            var now = DateTime.UtcNow;
            var employee = _db.Employees.Find(id);
            if (employee == null)
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "Employee to archive not found",
                    IsSuccess = false
                };
            try
            {
                employee.UpdatedOn = now;
                employee.IsArchived = true;
                _db.Employees.Update(employee);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "Customer Archived",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

        public Employee GetEmployeeById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}