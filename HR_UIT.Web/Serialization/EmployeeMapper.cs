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
                PrimaryAddress = EmployeeAddressMapper.MapEmployeeAddress(employee.PrimaryAddress),
                CreatedOn = employee.CreatedOn,
                UpdatedOn = employee.UpdatedOn,
                IsArchived = employee.IsArchived
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
            }
        }
    }
}