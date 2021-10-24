using System;
using System.Collections.Generic;
using System.Linq;
using HR_UIT.Data;
using HR_UIT.Data.Models;

namespace HR_UIT.Services.HolidayCreate
{
    public class HolidayCreateService : IHolidayCreateService
    {
        private readonly HrUitDbContext _db;

        public HolidayCreateService(HrUitDbContext dbContext)
        {
            _db = dbContext;
        }

        /// <summary>
        /// Return list of Holidays Off
        /// </summary>
        /// <returns></returns>
        public List<Data.Models.HolidayCreate> GetAllHolidaysOff()
        {
            return _db
                .HolidayCreates
                .OrderBy(holidayOff => holidayOff.Id)
                .ToList();
        }

        /// <summary>
        /// Get Holidays Off by Month
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public List<Data.Models.HolidayCreate> GetAllHolidaysOffByMonth(DateTime month)
        {
            return _db
                .HolidayCreates
                .Where((e => e.FromDate.Month == month.Month))
                .ToList();
        }

        /// <summary>
        /// Create new Holiday Off
        /// </summary>
        /// <param name="holidayOff;"></param>
        /// <returns></returns>
        public ServiceResponse<Data.Models.HolidayCreate> CreateHolidayOff(Data.Models.HolidayCreate holidayOff)
        {
            var now = DateTime.UtcNow;
            try
            {
                _db.HolidayCreates.Add(holidayOff);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.HolidayCreate>
                {
                    Data = holidayOff,
                    Time = now,
                    Message = "Saved new holiday Off",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.HolidayCreate>
                {
                    Data = null,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

        /// <summary>
        /// Update Holiday Off
        /// </summary>
        /// <param name="holidayOff"></param>
        /// <returns></returns>
        public ServiceResponse<Data.Models.HolidayCreate> UpdateHolidayOff(Data.Models.HolidayCreate holidayOff,
            int holidayOffId)
        {
            var now = DateTime.UtcNow;
            var newHolidayOff = _db.HolidayCreates.Find(holidayOffId);
            if (newHolidayOff == null)
                return new ServiceResponse<Data.Models.HolidayCreate>
                {
                    Data = null,
                    Time = now,
                    Message = "Holiday Off to Update Not Found",
                    IsSuccess = false
                };
            try
            {
                newHolidayOff.FromDate = holidayOff.FromDate;
                newHolidayOff.ToDate = holidayOff.ToDate;
                newHolidayOff.IsArchived = holidayOff.IsArchived;
                newHolidayOff.UpdatedOn = holidayOff.UpdatedOn;
                _db.HolidayCreates.Update(newHolidayOff);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.HolidayCreate>
                {
                    Data = newHolidayOff,
                    Time = now,
                    Message = $"Holiday Off {newHolidayOff.Id} updated!",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.HolidayCreate>
                {
                    Data = null,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

        /// <summary>
        /// Delete Holiday Off
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponse<bool> DeleteHolidayOff(int id)
        {
            var now = DateTime.UtcNow;
            var holidayOff = _db.HolidayCreates.Find(id);
            if (holidayOff == null)
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "Holiday Off to archive not found.",
                    IsSuccess = false
                };
            try
            {
                holidayOff.UpdatedOn = now;
                holidayOff.IsArchived = true;
                _db.HolidayCreates.Update(holidayOff);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "Holiday Off archived.",
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
        /// Recover Holiday Off
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponse<bool> RecoverHolidayOff(int id)
        {
            var now = DateTime.UtcNow;
            var holidayOff = _db.HolidayCreates.Find(id);
            if (holidayOff == null)
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "Holiday Off to recover not found!",
                    IsSuccess = false
                };
            try
            {
                holidayOff.UpdatedOn = now;
                holidayOff.IsArchived = false;
                _db.HolidayCreates.Update(holidayOff);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "Holiday Off recovered",
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

        public ServiceResponse<bool> AddHolidayCreateToEmployee(int holidayCreateId, int employeeId)
        {
            var now = DateTime.UtcNow;
            var currentEmployee = _db.Employees.Find(employeeId);
            var currentHolidayCreate = _db.HolidayCreates.Find(holidayCreateId);
            if (currentHolidayCreate == null || currentEmployee == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "Employee To Update or Holiday Create To Update Not Found",
                    IsSuccess = false
                };
            }

            if (currentHolidayCreate.IsExistedAdmin)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "Holiday Create Already Has Linked To Another Admin",
                    IsSuccess = false
                };
            }

            try
            {
                currentEmployee.EmployeeHolidayCreates ??= new List<Data.Models.HolidayCreate>();
                currentHolidayCreate.IsExistedAdmin = true;
                currentEmployee.EmployeeHolidayCreates.Add(currentHolidayCreate);
                _db.Update(currentEmployee);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "Holiday Create To Update Completed",
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

        public ServiceResponse<bool> RemoveHolidayCreateOutOfEmployee(int holidayCreateId, int employeeId)
        {
            var now = DateTime.UtcNow;
            var currentEmployee = _db.Employees.Find(employeeId);
            var currentHolidayCreate = _db.HolidayCreates.Find(holidayCreateId);
            if (currentHolidayCreate == null || currentEmployee == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "Employee To Update or Holiday Create To Update Not Found",
                    IsSuccess = false
                };
            }


            if (!currentHolidayCreate.IsExistedAdmin)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "Holiday Create Has Not Linked To Any Employee",
                    IsSuccess = false
                };
            }

            try
            {
                currentEmployee.EmployeeHolidayCreates ??= new List<Data.Models.HolidayCreate>();
                currentHolidayCreate.IsExistedAdmin = false;
                currentEmployee.EmployeeHolidayCreates.Remove(currentHolidayCreate);
                _db.Update(currentEmployee);
                _db.Update(currentHolidayCreate);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "Holiday Create To Update Completed",
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

        public ServiceResponse<bool> AddHolidayCreateToHoliday(int holidayCreateId, int holidayId)
        {
            var now = DateTime.UtcNow;
            var currentHoliday = _db.Holidays.Find(holidayId);
            var currentHolidayCreate = _db.HolidayCreates.Find(holidayCreateId);
            if (currentHolidayCreate == null || currentHoliday == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "Holiday To Update or Holiday Create To Update Not Found",
                    IsSuccess = false
                };
            }

            if (currentHolidayCreate.IsExistedHoliday)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "Holiday Create Already Has Linked To Another Holiday",
                    IsSuccess = false
                };
            }

            try
            {
                currentHoliday.PrimaryHolidayCreates ??= new List<Data.Models.HolidayCreate>();
                currentHolidayCreate.IsExistedHoliday = true;
                currentHoliday.PrimaryHolidayCreates.Add(currentHolidayCreate);
                _db.Update(currentHoliday);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "Holiday Create To Update Completed",
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

        public ServiceResponse<bool> RemoveHolidayCreateOutOfHoliday(int holidayCreateId, int holidayId)
        {
            var now = DateTime.UtcNow;
            var currentHoliday = _db.Holidays.Find(holidayId);
            var currentHolidayCreate = _db.HolidayCreates.Find(holidayCreateId);
            if (currentHolidayCreate == null || currentHoliday == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "Holiday To Update or Holiday Create To Update Not Found",
                    IsSuccess = false
                };
            }

            if (!currentHolidayCreate.IsExistedAdmin)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "Holiday Create Has Not Linked To Any Employee",
                    IsSuccess = false
                };
            }

            try
            {
                currentHoliday.PrimaryHolidayCreates ??= new List<Data.Models.HolidayCreate>();
                currentHolidayCreate.IsExistedAdmin = false;
                currentHoliday.PrimaryHolidayCreates.Remove(currentHolidayCreate);
                _db.Update(currentHoliday);
                _db.Update(currentHolidayCreate);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "Holiday Create To Update Completed",
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