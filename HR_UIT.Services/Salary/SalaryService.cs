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

        public ServiceResponse<Data.Models.EmployeeSalary> CheckSalary(int salaryId)
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
        
        public ServiceResponse<Data.Models.EmployeeSalary> ReceiveSalary(int salaryId)
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
        
        public Data.Models.EmployeeSalary GetEmployeeSalaryById(int id)
        {
            return _db
                .EmployeeSalaries
                .Find(id);
        }
        
        public Data.Models.EmployeeSalary GetEmployeeSalaryByYearMonth(int year, int month)
        {
            return _db
                .EmployeeSalaries
                .Include(salary => salary.PrimarySalaryDetail)
                .FirstOrDefault(e => e.Year == year && e.Month == month);

        }
        
    }
    
    
}