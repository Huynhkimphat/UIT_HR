using System;
using System.Collections.Generic;
using System.Linq;
using HR_UIT.Data;
namespace HR_UIT.Services.EmployeeType
{
    public class EmployeeTypeService:IEmployeeTypeService
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
            return _db.EmployeeTypes.Find(id);
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
            var now =DateTime.Now;
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
            var now =DateTime.UtcNow;
            var employeeType = _db.EmployeeTypes.Find(id);
            if (employeeType==null)
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
                employeeType.IsArchived = false ;
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
            var employeeType=_db.EmployeeTypes.Find(id);
            if (employeeType==null)
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
        /// Delete EmployeeType By Given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponse<bool> DeleteEmployeeType(int id)
        {
            var now =DateTime.UtcNow;
            var employeeType = _db.EmployeeTypes.Find(id);
            if (employeeType==null)
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
                employeeType.IsArchived = true ;
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