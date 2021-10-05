using System;
using System.Collections.Generic;

namespace HR_UIT.Services.EmployeeAttendance
{
    public interface IEmployeeAttendanceService
    {
        ServiceResponse<Data.Models.EmployeeAttendance>
            CreateNewEmployeeAttendance(
                Data.Models.EmployeeAttendance attendance
            );
            
        ServiceResponse<Data.Models.EmployeeAttendance>
            UpdateEmployeeAttendance(
                Data.Models.EmployeeAttendance attendance
            );

        List<Data.Models.EmployeeAttendance> GetEmployeeAttendancesByMonths(DateTime month);
        
        List<Data.Models.EmployeeAttendance> GetEmployeeAttendancesByWeeks(DateTime week);
        
        List<Data.Models.EmployeeAttendance> GetEmployeeAttendancesByDays(DateTime day);
        
        ServiceResponse<bool> DeleteEmployeeAttendance(int id);
        
        ServiceResponse<bool> RecoverEmployeeAttendance(int id);

        ServiceResponse<TimeSpan> CountAttendanceByMonth(DateTime month);
        
        ServiceResponse<TimeSpan> CountAttendanceByDay(DateTime day);
    }
}