using HR_UIT.Data.Models;
using HR_UIT.Web.ViewModels;

namespace HR_UIT.Web.Serialization
{
    public class EmployeeDayOffLetterMapper
    {
        /// <summary>
        /// Maps a EmployeeDayOffLetter Data Model to EmployeeDayOffLetter View Model
        /// </summary>
        /// <param name="dayOffLetter"></param>
        /// <returns></returns>
        public static EmployeeDayOffLetterModel
            EmployeeDayOff(EmployeeDayOffLetter dayOffLetter)
        {
            return new EmployeeDayOffLetterModel
            {
                Id = dayOffLetter.Id,
                FromDateTime = dayOffLetter.FromDateTime,
                ToDateTime = dayOffLetter.ToDateTime,
                Reason = dayOffLetter.Reason,
                CreatedOn = dayOffLetter.CreatedOn,
                UpdatedOn = dayOffLetter.UpdatedOn,
                IsArchived = dayOffLetter.IsArchived,
                IsApproved = dayOffLetter.IsApproved,
                DayOffCounting = dayOffLetter.DayOffCounting
            };
        }
        
        /// <summary>
        /// Maps a EmployeeDayOffLetter View Model to EmployeeDayOffLetter Data Model
        /// </summary>
        /// <param name="dayOffLetter"></param>
        /// <returns></returns>
        public static EmployeeDayOffLetter
            EmployeeDayOffLetter(EmployeeDayOffLetterModel dayOffLetter)
        {
            return new EmployeeDayOffLetter
            {
                FromDateTime = dayOffLetter.FromDateTime,
                ToDateTime = dayOffLetter.ToDateTime,
                Reason = dayOffLetter.Reason,
                CreatedOn = dayOffLetter.CreatedOn,
                UpdatedOn = dayOffLetter.UpdatedOn,
                IsArchived = dayOffLetter.IsArchived,
                IsApproved = dayOffLetter.IsApproved,
                DayOffCounting = dayOffLetter.DayOffCounting
            };
        }
    }
}