using HR_UIT.Data.Models;
using HR_UIT.Web.ViewModels;

namespace HR_UIT.Web.Serialization
{
    public static class EmployeeAttendanceMapper
    {
        /// <summary>
        ///     Maps an EmployeeAttendance Data Model to an EmployeeAttendance View Model 
        /// </summary>
        /// <param name="attendance"></param>
        /// <returns></returns>
        public static EmployeeAttendanceModel
            MapEmployeeAttendance(EmployeeAttendance attendance)
        {
            return new EmployeeAttendanceModel
            {
                Id = attendance.Id,
                FromDate = attendance.FromDate,
                ToDate = attendance.ToDate,
                IsProgressing = attendance.IsProgressing,
                Period = attendance.Period,
                CreatedOn = attendance.CreatedOn,
                UpdatedOn = attendance.UpdatedOn,
                IsArchived = attendance.IsArchived,
            };
        }

        /// <summary>
        ///     Maps an EmployeeAttendance View Model To an EmployeeAttendance Data Model
        /// </summary>
        /// <param name="attendance"></param>
        /// <returns></returns>
        public static EmployeeAttendance
            MapEmployeeAttendance(EmployeeAttendanceModel attendance)
        {
            return new EmployeeAttendance
            {
                FromDate = attendance.FromDate,
                ToDate = attendance.ToDate,
                IsProgressing = attendance.IsProgressing,
                Period = attendance.Period,
                CreatedOn = attendance.CreatedOn,
                UpdatedOn = attendance.UpdatedOn,
                IsArchived = attendance.IsArchived,
            };
        }
    }
}
