using System;
using System.Collections.Generic;
using System.Linq;
using HR_UIT.Data.Models;
using HR_UIT.Web.ViewModels;

namespace HR_UIT.Web.Serialization
{
    public static class EmployeeMapper
    {
        /// <summary>
        /// Maps an Employee data model to an Employee View Model
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public static EmployeeModel
            MapEmployee(Employee employee)
        {
            return new EmployeeModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                PhoneNumber = employee.PhoneNumber,
                IdentityCard = employee.IdentityCard,
                PrimaryAddress = (employee.PrimaryAddress != null)
                    ? EmployeeAddressMapper.MapEmployeeAddress(employee.PrimaryAddress)
                    : new EmployeeAddressModel { },
                PrimaryAccount = (employee.PrimaryAccount != null)
                    ? EmployeeAccountMapper.MapEmployeeAccount(employee.PrimaryAccount)
                    : new EmployeeAccountModel { },
                PrimarySalaries = (employee.PrimarySalaries != null)
                    ? employee.PrimarySalaries
                        .Select(EmployeeSalaryMapper.MapEmployeeSalary)
                        .OrderByDescending(salary => salary.Id)
                        .ToList()
                    : new List<EmployeeSalaryModel> { },
                CreatedOn = employee.CreatedOn,
                UpdatedOn = employee.UpdatedOn,
                IsArchived = employee.IsArchived,
                EmployeeAttendances = (employee.EmployeeAttendances != null)
                    ? employee.EmployeeAttendances
                        .Select(EmployeeAttendanceMapper.MapEmployeeAttendance)
                        .OrderByDescending(attendance => attendance.Id)
                        .ToList()
                    : new List<EmployeeAttendanceModel> { },
                PrimaryDayOff = (employee.PrimaryDayOff != null)
                    ? EmployeeDayOffMapper.MapEmployeeDayOff(employee.PrimaryDayOff)
                    : new EmployeeDayOffModel{ },
                PrimaryDayOffLetters = (employee.PrimaryDayOffLetters != null) 
                    ? employee.PrimaryDayOffLetters
                    .Select(EmployeeDayOffLetterMapper.MapEmployeeDayOffLetter)
                    .OrderByDescending(dayOffLetter => dayOffLetter.Id)
                    .ToList()
                    : new List<EmployeeDayOffLetterModel>{ }
            };
        }

        /// <summary>
        ///     Maps an Employee View Model To an Employee Data Model
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public static Employee
            MapEmployee(EmployeeModel employee)
        {
            var now = DateTime.UtcNow;
            return new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                PhoneNumber = employee.PhoneNumber,
                IdentityCard = employee.IdentityCard,
                PrimaryAddress = EmployeeAddressMapper.MapEmployeeAddress(employee.PrimaryAddress),
                PrimaryAccount = EmployeeAccountMapper.MapEmployeeAccount(employee.PrimaryAccount),
                PrimarySalaries = employee.PrimarySalaries?.Select(EmployeeSalaryMapper.MapEmployeeSalary).ToList(),
                EmployeeAttendances = employee.EmployeeAttendances?.Select(EmployeeAttendanceMapper.MapEmployeeAttendance).ToList(),
                PrimaryDayOff = EmployeeDayOffMapper.MapEmployeeDayOff(employee.PrimaryDayOff),
                PrimaryDayOffLetters = employee.PrimaryDayOffLetters?.Select(EmployeeDayOffLetterMapper.MapEmployeeDayOffLetter).ToList(),
                CreatedOn = now,
                UpdatedOn = now,
                IsArchived = employee.IsArchived
            };
        }
    }
}