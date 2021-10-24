using System;
using System.Collections.Generic;
using HR_UIT.Data;
using HR_UIT.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using HR_UIT.Services.Employee;

namespace HR_UIT.Services.Employee
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
        public List<Data.Models.Employee> GetAllEmployees()
        {
            return _db
                .Employees
                .Include(employee => employee.PrimaryAddress)
                .Include(employee => employee.PrimaryAccount)
                .Include(employee => employee.PrimarySalaries)
                .Include(employee => employee.EmployeeAttendances)
                .Include(employee => employee.PrimaryDayOff)
                .OrderBy(employee => employee.Id)
                .ToList();
        }

        /// <summary>
        /// Return a List of Employees from database which still available
        /// </summary>
        /// <returns></returns>
        public List<Data.Models.Employee> GetAllEmployeesVisible()
        {
            return _db
                .Employees
                .Where(employee => !employee.IsArchived)
                // .Include(employee => employee.PrimaryAddress)
                // .Include(employee => employee.PrimaryAccount)
                // .Include(employee => employee.PrimarySalaries)
                // .Include(employee => employee.EmployeeAttendances)
                // .Include(employee => employee.PrimaryDayOff)
                .OrderBy(employee => employee.Id)
                .ToList();
        }

        /// <summary>
        /// Create new Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public ServiceResponse<Data.Models.Employee> CreateEmployee(Data.Models.Employee employee)
        {
            var now = DateTime.UtcNow;
            employee.PrimarySalaries = null;
            employee.EmployeeAttendances = null;
            employee.EmployeeHolidayCreates = null;
            employee.PrimaryDayOff = null;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Data.Models.Employee GetEmployeeById(int id)
        {
            return _db
                .Employees.Find(id);

        }

        /// <summary>
        /// Update Employee
        /// </summary>
        /// <param name="newEmployee"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public ServiceResponse<Data.Models.Employee> UpdateEmployee(Data.Models.Employee newEmployee, int employeeId)
        {
            var now = DateTime.UtcNow;
            var employee = _db.Employees.Find(employeeId);
            if (employee == null)
                return new ServiceResponse<Data.Models.Employee>
                {
                    Data = null,
                    Time = now,
                    Message = "Employee to Update Not Found",
                    IsSuccess = false
                };
            try
            {
                employee.FirstName = newEmployee.FirstName;
                employee.LastName = newEmployee.LastName;
                employee.DateOfBirth = newEmployee.DateOfBirth;
                employee.PhoneNumber = newEmployee.PhoneNumber;
                employee.IdentityCard = newEmployee.IdentityCard;
                employee.UpdatedOn = newEmployee.UpdatedOn;
                employee.IsArchived = newEmployee.IsArchived;
                _db.Employees.Update(employee);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.Employee>
                {
                    Data = employee,
                    Time = now,
                    Message = $"Employee {employee.Id}  Updated!",
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

        /// <summary>
        /// Delete an Employee with given Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                    Message = "Employee Archived",
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

        /// <summary>
        /// Recover An Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ServiceResponse<bool> RecoverEmployee(int id)
        {
            var now = DateTime.UtcNow;
            var employee = _db.Employees.Find(id);
            if (employee == null)
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "Employee to recover not found",
                    IsSuccess = false
                };
            try
            {
                employee.UpdatedOn = now;
                employee.IsArchived = false;
                _db.Employees.Update(employee);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "Employee Recovered",
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
    }
}