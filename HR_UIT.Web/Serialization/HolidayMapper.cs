using System;
using HR_UIT.Web.ViewModels;
using System.Collections.Generic;
using HR_UIT.Data.Models;
using System.Linq;

namespace HR_UIT.Web.Serialization
{
    public static class HolidayMapper
    {
        /// <summary>
        ///     Maps an Holiday Data Model to an Holiday View Model
        /// </summary>
        /// <param name="holiday"></param>
        /// <returns></returns>
        public static HolidayModel
            MapHoliday(Holiday holiday)
        {
            return new HolidayModel
            {
                Id = holiday.Id,
                NameOfHoliday = holiday.NameOfHoliday,
                CreatedOn = holiday.CreatedOn,
                UpdateOn = holiday.UpdatedOn,
                DateOfHoliday = holiday.DateOfHoliday,     
                PrimaryHolidayCreate = (holiday.PrimaryHolidayCreate != null) 
                        ? HolidayCreateMapper.MapHolidayCreate(holiday.PrimaryHolidayCreate)
                                                                          : new HolidayCreateModel { },
                IsArchived = holiday.IsArchived
            };
        }

        /// <summary>
        ///     Maps an Holiday View Model To an Holiday Data Model
        /// </summary>
        /// <param name="holiday"></param>
        /// <returns></returns>
        public static Holiday
            MapHoliday(HolidayModel holiday)
        {
            var now = DateTime.UtcNow;
            return new Holiday
            {
                NameOfHoliday = holiday.NameOfHoliday,
                CreatedOn = now,
                UpdatedOn = now,
                DateOfHoliday = holiday.DateOfHoliday,
                PrimaryHolidayCreate = HolidayCreateMapper.MapHolidayCreate(holiday.PrimaryHolidayCreate),
                IsArchived = holiday.IsArchived
            };
        }
    }
}