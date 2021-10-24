using HR_UIT.Data.Models;
using HR_UIT.Web.ViewModels;

namespace HR_UIT.Web.Serialization
{
    public static class EmployeeDayOffLetterMapper
    {
        /// <summary>
        /// Maps an EmployeeDayOffLetter Data Model to an EmployeeDayOffLetter View Model
        /// </summary>
        /// <param name="dayOffLetter"></param>
        /// <returns></returns>
        public static EmployeeDayOffLetterModel
            MapEmployeeDayOffLetter(EmployeeDayOffLetter dayOffLetter)
        {
            return new EmployeeDayOffLetterModel
            {
                Id = dayOffLetter.Id,
                FromDateTime = dayOffLetter.FromDateTime,
                ToDateTime = dayOffLetter.ToDateTime,
                Reason = dayOffLetter.Reason,
                CreatedOn = dayOffLetter.CreatedOn,
                UpdatedOn = dayOffLetter.UpdatedOn,
                IsExisted = dayOffLetter.IsExisted,
                IsArchived = dayOffLetter.IsArchived,
                IsApproved = dayOffLetter.IsApproved,
                DayOffCounting = dayOffLetter.DayOffCounting
            };
        }

        /// <summary>
        /// Maps an EmployeeDayOffLetter View Model to an EmployeeDayOffLetter Data Model
        /// </summary>
        /// <param name="dayOffLetter"></param>
        /// <returns></returns>
        public static EmployeeDayOffLetter
            MapEmployeeDayOffLetter(EmployeeDayOffLetterModel dayOffLetter)
        {
            return new EmployeeDayOffLetter
            {
                FromDateTime = dayOffLetter.FromDateTime,
                ToDateTime = dayOffLetter.ToDateTime,
                Reason = dayOffLetter.Reason,
                CreatedOn = dayOffLetter.CreatedOn,
                UpdatedOn = dayOffLetter.UpdatedOn,
                IsExisted = dayOffLetter.IsExisted,
                IsArchived = dayOffLetter.IsArchived,
                IsApproved = dayOffLetter.IsApproved,
                DayOffCounting = dayOffLetter.DayOffCounting
            };
        }
    }
}