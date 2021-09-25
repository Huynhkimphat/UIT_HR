using HR_UIT.Data.Models;
using HR_UIT.Web.ViewModels;

namespace HR_UIT.Web.Serialization
{
    public static class EmployeeDayOffMapper
    {
        /// <summary>
        /// Maps a EmployeeDayOff Data Model to EmployeeDayOff View Model
        /// </summary>
        /// <param name="dayOff"></param>
        /// <returns></returns>
        public static EmployeeDayOffModel
            EmployeeDayOff(EmployeeDayOff dayOff)
        {
            return new EmployeeDayOffModel
            {
                Id = dayOff.Id,
                DayOffAmount = dayOff.DayOffAmount,
                CreatedOn = dayOff.CreatedOn,
                UpdatedOn = dayOff.UpdatedOn,
                IsArchived = dayOff.IsArchived
            };
        }
        
        /// <summary>
        /// Maps a EmployeeDayOff View Model to EmployeeDayOff Data Model
        /// </summary>
        /// <param name="dayOff"></param>
        /// <returns></returns>
        public static EmployeeDayOff
            EmployeeDayOff(EmployeeDayOffModel dayOff)
        {
            return new EmployeeDayOff
            {
                DayOffAmount = dayOff.DayOffAmount,
                CreatedOn = dayOff.CreatedOn,
                UpdatedOn = dayOff.UpdatedOn,
                IsArchived = dayOff.IsArchived
            };
        }
    }
}