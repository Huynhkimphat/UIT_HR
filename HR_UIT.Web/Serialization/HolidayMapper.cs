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
                PrimaryHolidayCreates = (holiday.PrimaryHolidayCreates != null)
                    ? holiday.PrimaryHolidayCreates
                        .Select(HolidayCreateMapper.MapHolidayCreate)
                        .OrderByDescending(holidayCreate=>holidayCreate.Id)
                        .ToList()
                    : new List<HolidayCreateModel> { },
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
                PrimaryHolidayCreates = (holiday.PrimaryHolidayCreates != null)
                                    ? holiday.PrimaryHolidayCreates
                                        .Select(HolidayCreateMapper.MapHolidayCreate)
                                        .OrderByDescending(holidayCreate=>holidayCreate.Id)
                                        .ToList()
                                    : new List<HolidayCreate> { },
                IsArchived = holiday.IsArchived
            };
        }
    }
}