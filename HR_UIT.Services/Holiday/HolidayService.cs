using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using HR_UIT.Data;
using HR_UIT.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HR_UIT.Services.Holiday
{
    public class HolidayService : IHolidayService
    {
        private readonly HrUitDbContext _db;

        public HolidayService(HrUitDbContext dbContext)
        {
            _db = dbContext;
        }
        
        /// <summary>
        /// Return a list of Holidays
        /// </summary>
        /// <returns></returns>
        public List<Data.Models.Holiday> GetAllHolidays()
        {
            return _db //HrUitDbContext
                .Holidays
                .OrderBy(holiday => holiday.Id)
                .ToList();
        }
        
        /// <summary>
        /// Return a list of Holiday get by month
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public List<Data.Models.Holiday> GetHolidaysByMonth(DateTime month)
        {
            return _db
                .Holidays
                .Include(holiday => holiday.PrimaryHoliday_Create.FromDate)
                .Where(e => e.PrimaryHoliday_Create.FromDate.Month == month.Month)
                .ToList();
        }
        
        /// <summary>
        /// Create new Holiday
        /// </summary>
        /// <param name="holiday"></param>
        /// <returns></returns>
        public ServiceResponse<Data.Models.Holiday> CreateHoliday(Data.Models.Holiday holiday)
        {
            var now = DateTime.UtcNow;
            try
            {
                _db.Holidays.Add(holiday);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.Holiday>
                {
                    Data = holiday,
                    Time = now,
                    Message = "Saved new holiday",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.Holiday>
                {
                    Data = null,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

        /// <summary>
        /// Update Name of Holiday
        /// </summary>
        /// <param name="holiday"></param>
        /// <returns></returns>
        
        public ServiceResponse<Data.Models.Holiday> UpdateNameOfHoliday(string name, int holidayId)
        {
            var now = DateTime.UtcNow;
            var holiday = _db.Holidays.Find(holidayId);
            if (holiday == null)
                return new ServiceResponse<Data.Models.Holiday>
                {
                    Data = null,
                    Time = now,
                    Message = "Holiday to Update Not Found",
                    IsSuccess = false
                };
            try
            {
                holiday.UpdatedOn = now;
                holiday.NameOfHoliday = name;
                _db.Holidays.Update(holiday);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.Holiday>
                {
                    Data = holiday,
                    Time = now,
                    Message = $"Name of Holiday {holiday.Id} updated!",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.Holiday>
                {
                    Data = null,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

        /// <summary>
        /// Get Holiday by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
            
        public Data.Models.Holiday GetHolidayById(int id)
        {
            return _db.Holidays.Find(id);
        }

        /// <summary>
        /// Delete a Holiday
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponse<bool> DeleteHoliday(int id)
        {
            var now = DateTime.UtcNow;
            var holiday = _db.Holidays.Find(id);
            if (holiday == null)
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "Holiday to archive not found.",
                    IsSuccess = false
                };
            try
            {
                holiday.UpdatedOn = now;
                holiday.IsArchived = true;
                _db.Holidays.Update(holiday);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "Holiday archived.",
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
        /// Recover a Holiday
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        public ServiceResponse<bool> RecoverHoliday(int id)
        {
            var now = DateTime.UtcNow;
            var holiday = _db.Holidays.Find(id);
            if (holiday == null)
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "Holiday to recover not found",
                    IsSuccess = false
                };
            try
            {
                holiday.UpdatedOn = now;
                holiday.IsArchived = false;
                _db.Holidays.Update(holiday);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "Holiday Recovered",
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