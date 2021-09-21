using System;
using System.Collections.Generic;
using HR_UIT.Data;
using System.Linq;

namespace HR_UIT.Services.EmployeeAddress
{
    public class EmployeeAddressService :IEmployeeAddressService
    {
        private readonly HrUitDbContext _db;

        public EmployeeAddressService(HrUitDbContext dbContext)
        {
            _db = dbContext;
        }
        
        /// <summary>
        /// Get a List of EmployeeAddress from database
        /// </summary>
        /// <returns></returns>
        public List<Data.Models.EmployeeAddress> GetEmployeeAddresses()
        {
            return _db.EmployeeAddresses
                .OrderBy(employeeAddress => employeeAddress.Id)
                .ToList();
        }

        
        /// <summary>
        /// Create new employeeAddress
        /// </summary>
        /// <param name="employeeAddress"></param>
        /// <returns></returns>
        public ServiceResponse<Data.Models.EmployeeAddress> 
            CreateEmployeeAddress(Data.Models.EmployeeAddress employeeAddress)
        {
            var now = DateTime.UtcNow;
            try
            {
                _db.EmployeeAddresses.Add(employeeAddress);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.EmployeeAddress>
                {
                    Data = employeeAddress,
                    Time = now,
                    Message = "Saved New EmployeeAddress",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.EmployeeAddress>
                {
                    Data = null,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
                
        }

        
        /// <summary>
        /// Get EmployeeAddress By Given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Data.Models.EmployeeAddress GetEmployeeAddressById(int id)
        {
            return _db.EmployeeAddresses.Find(id);

        }
        
        /// <summary>
        /// Update An EmployeeAddress 
        /// </summary>
        /// <param name="employeeAddress"></param>
        /// <returns></returns>
        public ServiceResponse<Data.Models.EmployeeAddress> UpdateEmployeeAddress(Data.Models.EmployeeAddress employeeAddress)
        {
            var now = DateTime.UtcNow;
            try
            {
                _db.EmployeeAddresses.Update(employeeAddress);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.EmployeeAddress>
                {
                    Data = employeeAddress,
                    Time = now,
                    Message = $"Updated EmployeeAddress {employeeAddress.Id}",
                    IsSuccess = true,
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.EmployeeAddress>
                {
                    Data = null,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false,
                };
            }
        }
    }
}