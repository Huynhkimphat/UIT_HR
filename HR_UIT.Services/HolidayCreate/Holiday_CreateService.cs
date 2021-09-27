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
        public List<Data.Models.Holiday_Create> GetAllHolidaysOff()
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
        public List<Data.Models.Holiday_Create> GetAllHolidaysOffByMonth(DateTime month)
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
        public ServiceResponse<Data.Models.Holiday_Create> CreateHolidayOff(Data.Models.Holiday_Create holidayOff)
        {
            var now = DateTime.UtcNow;
            try
            {
                _db.HolidayCreates.Add(holidayOff);
                _db.SaveChanges();
                return new ServiceResponse<Holiday_Create>
                {
                    Data = holidayOff,
                    Time = now,
                    Message = "Saved new holiday Off",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Holiday_Create>
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
        
        public ServiceResponse<Data.Models.Holiday_Create> UpdateHolidayOff(Data.Models.Holiday_Create holidayOff)
        {
            var now = DateTime.UtcNow;
            try
            {
                _db.HolidayCreates.Update(holidayOff);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.Holiday_Create>
                {
                    Data = holidayOff,
                    Time = now,
                    Message = $"Holiday Off {holidayOff.Id} updated!",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.Holiday_Create>
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
    }
}