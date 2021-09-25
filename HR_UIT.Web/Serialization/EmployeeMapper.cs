using System.Collections.Generic;
using System.Linq;
using HR_UIT.Data.Models;
using HR_UIT.Web.ViewModels;

namespace HR_UIT.Web.Serialization
{
    public static class EmployeeMapper
    {
        /// <summary>
        /// Maps a Employee data model to Employee View Model
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
                PrimaryAddress = (employee.PrimaryAddress is not null) 
                    ? EmployeeAddressMapper.MapEmployeeAddress(employee.PrimaryAddress)
                    : new EmployeeAddressModel {},
                CreatedOn = employee.CreatedOn,
                UpdatedOn = employee.UpdatedOn,
                IsArchived = employee.IsArchived,
                EmployeeHolidayCreates = (employee.EmployeeHoliday_Creates is not null) ? employee.EmployeeHoliday_Creates
                    .Select(HolidayCreateMapper.MapHolidayCreate)
                    .OrderByDescending(holidayCreate => holidayCreate.Id)
                    .ToList() : new List<HolidayCreateModel>{}
                
            };
        }

        public static Employee
            MapEmployee(EmployeeModel employee)
        {
            return new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                PhoneNumber = employee.PhoneNumber,
                IdentityCard = employee.IdentityCard,
                PrimaryAddress = EmployeeAddressMapper.MapEmployeeAddress(employee.PrimaryAddress),
                CreatedOn = employee.CreatedOn,
                UpdatedOn = employee.UpdatedOn,
                IsArchived = employee.IsArchived
            };
        }
    }
}