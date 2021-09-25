using System.Collections.Generic;
using HR_UIT.Data.Models;
using HR_UIT.Web.ViewModels;
namespace HR_UIT.Web.Serialization
{
    public static class HolidayCreateMapper
    {
        public static HolidayCreateModel
            MapHolidayCreate(Holiday_Create holidayCreate)
        {
            return new HolidayCreateModel
            {
                Id = holidayCreate.Id,
                FromDate = holidayCreate.FromDate,
                ToDate = holidayCreate.ToDate,
                CreatedOn = holidayCreate.CreatedOn,
                UpdatedOn = holidayCreate.UpdatedOn,
                IsArchived = holidayCreate.IsArchived
            };
        }

        public static Holiday_Create
            MapHolidayCreate(HolidayCreateModel holidayCreate)
        {
            return new Holiday_Create
            {
                FromDate = holidayCreate.FromDate,
                ToDate = holidayCreate.ToDate,
                CreatedOn = holidayCreate.CreatedOn,
                UpdatedOn = holidayCreate.UpdatedOn,
                IsArchived = holidayCreate.IsArchived
            };
        }
    }
    
}