using System;
using System.Collections.Generic;
using System.Linq;
using HR_UIT.Data;
using Microsoft.EntityFrameworkCore;

namespace HR_UIT.Services.EmployeeType
{
    public class EmployeeTypeService : IEmployeeTypeService
    {
        private readonly HrUitDbContext _db;

        public EmployeeTypeService(HrUitDbContext dbContext)
        {
            _db = dbContext;
        }

        /// <summary>
        /// Return a list of EmployeeType
        /// </summary>
        /// <returns></returns>
        public List<Data.Models.EmployeeType> GetAllEmployeeTypes()
        {
            return _db.EmployeeTypes
                .Include(employeeType => employeeType.Employees)
                    .ThenInclude(employee => employee.PrimaryAddress)
                .Include(employeeType => employeeType.Employees)
                    .ThenInclude(employee => employee.PrimaryAccount)
                .OrderBy(employeeType => employeeType.Id)
                .ToList();
        }

        /// <summary>
        /// Get Type By a Given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Data.Models.EmployeeType GetTypeById(int id)
        {
            return _db.EmployeeTypes
                .Include(employeeType => employeeType.Employees)
                .ThenInclude(employee => employee.PrimaryAddress)
                .FirstOrDefault(type => type.Id == id);
        }

        /// <summary>
        /// Create New EmployeeType
        /// </summary>
        /// <param name="employeeType"></param>
        /// <returns></returns>
        public ServiceResponse<Data.Models.EmployeeType>
            CreateEmployeeType(
                Data.Models.EmployeeType employeeType
            )
        {
            var now = DateTime.Now;
            employeeType.Employees = null;
            try
            {
                _db.EmployeeTypes.Add(employeeType);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.EmployeeType>
                {
                    Data = employeeType,
                    Time = now,
                    Message = "Saved new employeeType",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.EmployeeType>
                {
                    Data = null,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

        /// <summary>
        /// Recover EmployeeType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ServiceResponse<bool> RecoverEmployeeType(int id)
        {
            var now = DateTime.UtcNow;
            var employeeType = _db.EmployeeTypes.Find(id);
            if (employeeType == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "EmployeeType To Recover Not Found",
                    IsSuccess = false
                };
            }

            try
            {
                employeeType.IsArchived = false;
                _db.Update(employeeType);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "EmployeeType To Recover Completed",
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
        /// Update EmployeeType's Name By Given Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public ServiceResponse<Data.Models.EmployeeType>
            UpdateEmployeeTypeName(
                int id, string typeName
            )
        {
            var now = DateTime.UtcNow;
            var employeeType = _db.EmployeeTypes.Find(id);
            if (employeeType == null)
            {
                return new ServiceResponse<Data.Models.EmployeeType>
                {
                    Data = null,
                    Time = now,
                    Message = "EmployeeType To Update Not Found",
                    IsSuccess = false
                };
            }

            try
            {
                employeeType.Name = typeName;
                employeeType.UpdatedOn = now;
                _db.Update(employeeType);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.EmployeeType>
                {
                    Data = employeeType,
                    Time = now,
                    Message = "EmployeeType To Update Completed",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.EmployeeType>
                {
                    Data = null,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

        /// <summary>
        /// Add Employee To Type With Given Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ServiceResponse<Data.Models.EmployeeType> UpdateEmployeeTypeEmployees(int typeId, int employeeId)
        {
            var now = DateTime.UtcNow;
            var currentType = _db.EmployeeTypes.Find(typeId);
            var currentEmployee = _db.Employees
                .Include(employee => employee.PrimaryAddress)
                .FirstOrDefault(employee => employee.Id == employeeId);
            ;
            if (currentType == null || currentEmployee == null)
            {
                return new ServiceResponse<Data.Models.EmployeeType>
                {
                    Data = null,
                    Time = now,
                    Message = "EmployeeType To Update or Employee To Update Not Found",
                    IsSuccess = false
                };
            }

            try
            {
                currentType.Employees ??= new List<Data.Models.Employee>();
                currentType.Employees.Add(currentEmployee);
                _db.Update(currentType);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.EmployeeType>
                {
                    Data = currentType,
                    Time = now,
                    Message = "EmployeeType To Update Completed",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.EmployeeType>
                {
                    Data = null,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }


        /// <summary>
        /// Remove Employee Out Of Type
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public ServiceResponse<bool> RemoveEmployeeTypeEmployees(int employeeId)
        {
            var now = DateTime.UtcNow;
            var currentTypes = _db.EmployeeTypes
                .Include(employeeType => employeeType.Employees)
                .ThenInclude(employee => employee.PrimaryAddress)
                .OrderBy(employeeType => employeeType.Id)
                .ToList();
            var currentEmployee = _db.Employees
                .Include(employee => employee.PrimaryAddress)
                .FirstOrDefault(employee => employee.Id == employeeId);
            ;
            if (currentEmployee == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "Employee To Update Not Found",
                    IsSuccess = false
                };
            }

            try
            {
                foreach (var currentType in currentTypes.Where(currentType => currentType.Employees != null))
                {
                    currentType.Employees.RemoveAll(employee => employee.Id == currentEmployee.Id);
                    _db.Update(currentType);
                }

                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "EmployeeType To Update Completed",
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
        /// Return Whether Employee Has Role Or Not
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ServiceResponse<bool> IsEmployeeHasRole(int employeeId)
        {
            var now = DateTime.UtcNow;
            var currentTypes = _db.EmployeeTypes
                .Include(employeeType => employeeType.Employees)
                .ThenInclude(employee => employee.PrimaryAddress)
                .OrderBy(employeeType => employeeType.Id)
                .ToList();
            var currentEmployee = _db.Employees
                .Include(employee => employee.PrimaryAddress)
                .FirstOrDefault(employee => employee.Id == employeeId);
            ;
            if (currentEmployee == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "Employee To Check Role Not Found",
                    IsSuccess = false
                };
            }

            try
            {
                var isEmployeeHasRole = false;
                foreach (var currentType in currentTypes.Where(currentType => currentType.Employees != null))
                {
                    isEmployeeHasRole = currentType.Employees.Any(employee => employee.Id == employeeId);;
                }

                if (isEmployeeHasRole)
                {
                    return  new ServiceResponse<bool>
                    {
                        Data = true,
                        Time = now,
                        Message = $"Employee {employeeId} is exist role",
                        IsSuccess = true
                    };
                }
                return  new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = $"Employee {employeeId} is not exist role",
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
        /// Delete EmployeeType By Given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponse<bool> DeleteEmployeeType(int id)
        {
            var now = DateTime.UtcNow;
            var employeeType = _db.EmployeeTypes.Find(id);
            if (employeeType == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "EmployeeType To Archive Not Found",
                    IsSuccess = false
                };
            }

            try
            {
                employeeType.IsArchived = true;
                _db.Update(employeeType);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "EmployeeType To Archive Completed",
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