using System;
using System.Linq;
using System.Collections.Generic;
using HR_UIT.Data;
namespace HR_UIT.Services.EmployeeDayOffService
{

    public class EmployeeDayOffService
    {
        private readonly HrUitDbContext _db;

        public EmployeeDayOffService(HrUitDbContext dbContext)
        {
            _db = dbContext;
        }

        /// <summary>
        /// Create new employeeDayOff
        /// </summary>
        /// <param name="employeeDayOff"></param>
        /// <returns></returns>
        public ServiceResponse<Data.Models.EmployeeDayOff>
            CreateNewEmployeeDayOff(Data.Models.EmployeeDayOff employeeDayOff)
        {
            var now = DateTime.UtcNow;
            try
            {
                _db.EmployeeDayOffs.Add(employeeDayOff);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.EmployeeDayOff>
                {
                    Data = employeeDayOff,
                    Time = now,
                    Message = "Save new EmployeeDayOff",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.EmployeeDayOff>
                {
                    Data = null,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }
        
        /// <summary>
        /// Update an EmployeeDayOff
        /// </summary>
        /// <param name="employeeDayOff"></param>
        /// <returns></returns>
         public ServiceResponse<Data.Models.EmployeeDayOff>
            UpdateEmployeeDayOffLetter(Data.Models.EmployeeDayOff employeeDayOff, int employeeDayOffId)
        {
            var now = DateTime.UtcNow;
            var newEmployeeDayOff = _db.EmployeeDayOffs.Find(employeeDayOffId);
            if (newEmployeeDayOff == null)
                return new ServiceResponse<Data.Models.EmployeeDayOff>
                {
                    Data = null,
                    Time = now,
                    Message = "EmployeeDayOff to Update Not Found",
                    IsSuccess = false
                };
            try
            {
                newEmployeeDayOff.DayOffAmount = employeeDayOff.DayOffAmount;
                newEmployeeDayOff.CreatedOn = employeeDayOff.CreatedOn;
                newEmployeeDayOff.UpdatedOn =employeeDayOff.UpdatedOn;
                newEmployeeDayOff.IsArchived = employeeDayOff.IsArchived;
                _db.EmployeeDayOffs.Update(newEmployeeDayOff);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.EmployeeDayOff>
                {
                    Data = newEmployeeDayOff,
                    Time = now,
                    Message = $"EmployeeDayOff {newEmployeeDayOff.Id}  Updated!",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.EmployeeDayOff>
                {
                    Data = null,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

        /// <summary>
        /// get a list of EmployeeDayOffs from database 
        /// </summary>
        /// <returns></returns>
        public List<Data.Models.EmployeeDayOff> GetAllEmployeeDayOff()
        {
            return _db.EmployeeDayOffs
                .OrderBy(employeeDayOff => employeeDayOff.Id)
                .ToList();
        }

        /// <summary>
        /// Get a employeeDayOff by given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Data.Models.EmployeeDayOff GetEmployeeDayOffById(int id)
        {
            return _db.EmployeeDayOffs.Find(id);
        }

        /// <summary>
        /// Delete an Employee with given Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponse<bool> DeleteEmployee(int id)
        {
            var now = DateTime.UtcNow;
            var employeeDayOff = _db.EmployeeDayOffs.Find(id);
            if (employeeDayOff == null)
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "EmployeeDayOff to archive not found",
                    IsSuccess = false
                };
            try
            {
                employeeDayOff.IsArchived = true;
                employeeDayOff.UpdatedOn = now;
                _db.EmployeeDayOffs.Update(employeeDayOff);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "EmployeeDayOff archive",
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
        /// Recover an Employee with given Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponse<bool> RecoverEmployeeDayOff(int id)
        {
            var now = DateTime.UtcNow;
            var employeeDayOff = _db.EmployeeDayOffs.Find(id);
            if (employeeDayOff == null)
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "EmployeeDayOff to recover not found",
                    IsSuccess = false
                };
            try
            {
                employeeDayOff.IsArchived = false;
                employeeDayOff.UpdatedOn = now;
                _db.EmployeeDayOffs.Update(employeeDayOff);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "EmployeeDayOff recover",
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