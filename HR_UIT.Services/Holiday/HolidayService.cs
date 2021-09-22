using System;
using System.Collections.Generic;
using System.Linq;
using HR_UIT.Data;
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

        public List<Data.Models.Holiday> GetAllHolidays()
        {
            return _db //HrUitDbContext
                .Holidays
                .Include(holiday => holiday.PrimaryHoliday_Create)
                .OrderBy(holiday => holiday.Id)
                .ToList();
        }

        public List<Data.Models.Holiday> GetAllHolidaysVisible()
        {
            return _db //HrUitDbContext
                .Holidays
                .Include(holiday => holiday.PrimaryHoliday_Create)
                .Where(holiday => !holiday.IsArchived)
                .OrderBy(holiday => holiday.Id)
                .ToList();
        }

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

        public ServiceResponse<Data.Models.Holiday> UpdateHoliday(Data.Models.Holiday holiday)
        {
            var now = DateTime.UtcNow;
            try
            {
                _db.Holidays.Update(holiday);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.Holiday>
                {
                    Data = holiday,
                    Time = now,
                    Message = $"Holiday {holiday.Id} updated!",
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

        public Data.Models.Holiday GetHolidayById(int id)
        {
            return _db.Holidays.Include(holiday => holiday.Id).FirstOrDefault(e => e.Id == id);
        }
    }
    
    

}