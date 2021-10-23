using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using HR_UIT.Data;
using HR_UIT.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HR_UIT.Services.Salary

{
    public class SalaryService : ISalaryService
    {
        private readonly HrUitDbContext _db;

        public SalaryService(HrUitDbContext dbContext)
        {
            _db = dbContext;
        }

        /// <summary>
        /// Create new Employee Salary
        /// </summary>
        /// <param name="salary"></param>
        /// <returns></returns>
        public ServiceResponse<Data.Models.EmployeeSalary> CreateEmployeeSalary(Data.Models.EmployeeSalary salary)
        {
            var now = DateTime.UtcNow;
            try
            {
                _db.EmployeeSalaries.Add(salary);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.EmployeeSalary>
                {
                    Data = salary,
                    Time = now,
                    Message = "Saved new employee Salary",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.EmployeeSalary>
                {
                    Data = null,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

        /// <summary>
        /// Update employee salary
        /// </summary>
        /// <param name="newSalary"></param>
        /// <param name="salaryId"></param>
        /// <returns></returns>
        public ServiceResponse<Data.Models.EmployeeSalary> UpdateEmployeeSalary(Data.Models.EmployeeSalary newSalary,
            int salaryId)
        {
            var now = DateTime.UtcNow;
            var salary = _db.EmployeeSalaries.Find(salaryId);
            if (salary == null)
                return new ServiceResponse<Data.Models.EmployeeSalary>
                {
                    Data = null,
                    Time = now,
                    Message = "Employee Salary to Update not Found",
                    IsSuccess = false
                };
            try
            {
                salary.Month = newSalary.Month;
                salary.Year = newSalary.Year;
                salary.UpdatedOn = newSalary.UpdatedOn;
                salary.IsArchived = newSalary.IsArchived;
                _db.EmployeeSalaries.Update(salary);
                _db.SaveChanges();
                return new ServiceResponse<EmployeeSalary>
                {
                    Data = salary,
                    Time = now,
                    Message = $"Salary {salary.Id}  Updated!",
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<EmployeeSalary>
                {
                    Data = null,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

        /// <summary>
        /// Check Salary By Given Id
        /// </summary>
        /// <param name="salaryId"></param>
        /// <returns></returns>
        public ServiceResponse<Data.Models.EmployeeSalary> IsCheckedSalary(int salaryId)
        {
            var now = DateTime.UtcNow;
            var salary = _db.EmployeeSalaries.Find(salaryId);
            if (salary == null)
                return new ServiceResponse<Data.Models.EmployeeSalary>
                {
                    Data = null,
                    Time = now,
                    Message = "Employee salary to Update not Found",
                    IsSuccess = false
                };
            try
            {
                salary.IsChecked = true;
                salary.UpdatedOn = now;
                _db.EmployeeSalaries.Update(salary);
                _db.SaveChanges();
                return new ServiceResponse<EmployeeSalary>
                {
                    Data = salary,
                    Time = now,
                    Message = $"Employee salary {salary.Id} Checked!",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<EmployeeSalary>
                {
                    Data = null,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

        /// <summary>
        /// UnCheck Salary By Given Id
        /// </summary>
        /// <param name="salaryId"></param>
        /// <returns></returns>
        public ServiceResponse<EmployeeSalary> IsUnCheckedSalary(int salaryId)
        {
            var now = DateTime.UtcNow;
            var salary = _db.EmployeeSalaries.Find(salaryId);
            if (salary == null)
                return new ServiceResponse<Data.Models.EmployeeSalary>
                {
                    Data = null,
                    Time = now,
                    Message = "Employee salary to Update not Found",
                    IsSuccess = false
                };
            try
            {
                salary.IsChecked = false;
                salary.UpdatedOn = now;
                _db.EmployeeSalaries.Update(salary);
                _db.SaveChanges();
                return new ServiceResponse<EmployeeSalary>
                {
                    Data = salary,
                    Time = now,
                    Message = $"Employee salary {salary.Id} Checked!",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<EmployeeSalary>
                {
                    Data = null,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

        /// <summary>
        /// UnReceived Salary By Salary Id
        /// </summary>
        /// <param name="salaryId"></param>
        /// <returns></returns>
        public ServiceResponse<EmployeeSalary> IsUnReceivedSalary(int salaryId)
        {
            var now = DateTime.UtcNow;
            var salary = _db.EmployeeSalaries.Find(salaryId);
            if (salary == null)
                return new ServiceResponse<Data.Models.EmployeeSalary>
                {
                    Data = null,
                    Time = now,
                    Message = "Employee salary to Update not Found",
                    IsSuccess = false
                };
            try
            {
                salary.IsReceived = false;
                salary.UpdatedOn = now;
                _db.EmployeeSalaries.Update(salary);
                _db.SaveChanges();
                return new ServiceResponse<EmployeeSalary>
                {
                    Data = salary,
                    Time = now,
                    Message = $"Employee salary {salary.Id} Checked!",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<EmployeeSalary>
                {
                    Data = null,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

        /// <summary>
        /// Delete Salary By Given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponse<bool> DeleteSalary(int id)
        {
            var now = DateTime.UtcNow;
            var salary = _db.EmployeeSalaries.Find(id);
            if (salary == null)
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "Salary to archive not found",
                    IsSuccess = false
                };
            try
            {
                salary.UpdatedOn = now;
                salary.IsArchived = true;
                _db.EmployeeSalaries.Update(salary);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "Salary Archived",
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
        /// Recover Salary By Given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponse<bool> RecoverSalary(int id)
        {
            var now = DateTime.UtcNow;
            var salary = _db.EmployeeSalaries.Find(id);
            if (salary == null)
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "Salary to archive not found",
                    IsSuccess = false
                };
            try
            {
                salary.UpdatedOn = now;
                salary.IsArchived = false;
                _db.EmployeeSalaries.Update(salary);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "Salary Archived",
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
        /// Received Salary By Given Id
        /// </summary>
        /// <param name="salaryId"></param>
        /// <returns></returns>
        public ServiceResponse<Data.Models.EmployeeSalary> IsReceivedSalary(int salaryId)
        {
            var now = DateTime.UtcNow;
            var salary = _db.EmployeeSalaries.Find(salaryId);
            if (salary == null)
                return new ServiceResponse<Data.Models.EmployeeSalary>
                {
                    Data = null,
                    Time = now,
                    Message = "Employee salary to Update not Found",
                    IsSuccess = false
                };
            try
            {
                salary.IsReceived = true;
                salary.UpdatedOn = DateTime.Now;
                _db.EmployeeSalaries.Update(salary);
                _db.SaveChanges();
                return new ServiceResponse<EmployeeSalary>
                {
                    Data = salary,
                    Time = now,
                    Message = $"Employee salary {salary.Id} Received!",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<EmployeeSalary>
                {
                    Data = null,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

        /// <summary>
        /// Get Employee Salary By Given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Data.Models.EmployeeSalary GetEmployeeSalaryById(int id)
        {
            return _db
                .EmployeeSalaries
                .Find(id);
        }

        /// <summary>
        /// Get EmployeeSalary By Given Month and Year
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public Data.Models.EmployeeSalary GetEmployeeSalaryByYearMonth(int year, int month)
        {
            return _db
                .EmployeeSalaries
                .Include(salary => salary.PrimarySalaryDetail)
                .FirstOrDefault(e => e.Year == year && e.Month == month);
        }

        public ServiceResponse<bool> AddSalaryToEmployee(int salId, int empId)
        {
            var now = DateTime.UtcNow;
            var currentEmployee = _db.Employees.Find(empId);
            var currentSalary = _db.EmployeeSalaries.Find(salId);
            if (currentSalary == null || currentEmployee == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "Employee To Update or Salary To Update Not Found",
                    IsSuccess = false
                };
            }

            if (currentSalary.IsExisted)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "Salary Already Has Linked To Another Employee",
                    IsSuccess = false
                };
            }

            try
            {
                currentEmployee.PrimarySalaries ??= new List<Data.Models.EmployeeSalary>();
                currentEmployee.PrimarySalaries.Add(currentSalary);
                currentSalary.IsExisted = true;
                _db.Update(currentEmployee);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "Salary To Update Completed",
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

        public ServiceResponse<bool> RemoveSalaryOutOfEmployee(int salId, int empId)
        {
            var now = DateTime.UtcNow;
            var currentEmployee = _db.Employees.Find(empId);
            var currentSalary = _db.EmployeeSalaries.Find(salId);
            if (currentSalary == null || currentEmployee == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "Employee To Update or Salary To Update Not Found",
                    IsSuccess = false
                };
            }

            if (!currentSalary.IsExisted)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "Salary Has Not Linked To Any Employee",
                    IsSuccess = false
                };
            }

            try
            {
                currentEmployee.PrimarySalaries ??= new List<Data.Models.EmployeeSalary>();
                currentEmployee.PrimarySalaries.Remove(currentSalary);
                currentSalary.IsExisted = false;
                _db.Update(currentEmployee);
                _db.Update(currentSalary);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "Salary To Update Completed",
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