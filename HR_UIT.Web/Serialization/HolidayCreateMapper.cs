using System.Collections.Generic;
using HR_UIT.Data.Models;
using HR_UIT.Web.ViewModels;

namespace HR_UIT.Web.Serialization
{
    public static class HolidayCreateMapper
    {
        /// <summary>
        ///     Maps an HolidayCreate Data Model to an Holiday View Model
        /// </summary>
        /// <param name="holidayCreate"></param>
        /// <returns></returns>
        public static HolidayCreateModel
            MapHolidayCreate(HolidayCreate holidayCreate)
        {
            return new HolidayCreateModel
            {
                Id = holidayCreate.Id,
                FromDate = holidayCreate.FromDate,
                ToDate = holidayCreate.ToDate,
                CreatedOn = holidayCreate.CreatedOn,
                UpdatedOn = holidayCreate.UpdatedOn,
                IsExistedHoliday = holidayCreate.IsExistedHoliday,
                IsExistedAdmin = holidayCreate.IsExistedAdmin,
                IsArchived = holidayCreate.IsArchived
            };
        }

        /// <summary>
        ///     Map an HolidayCreate View Model To an Holiday Create Data Model
        /// </summary>
        /// <param name="holidayCreate"></param>
        /// <returns></returns>
        public static HolidayCreate
            MapHolidayCreate(HolidayCreateModel holidayCreate)
        {
            return new HolidayCreate
            {
                FromDate = holidayCreate.FromDate,
                ToDate = holidayCreate.ToDate,
                CreatedOn = holidayCreate.CreatedOn,
                UpdatedOn = holidayCreate.UpdatedOn,
                IsArchived = holidayCreate.IsArchived, 
                IsExistedHoliday = holidayCreate.IsExistedHoliday,
                IsExistedAdmin = holidayCreate.IsExistedAdmin,
            };
        }
    }
}