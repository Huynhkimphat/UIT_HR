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
                Data.Models.EmployeeAttendance attendance, int attendanceId
            );

        List<Data.Models.EmployeeAttendance> GetEmployeeAttendancesByMonths(DateTime month);

        List<Data.Models.EmployeeAttendance> GetEmployeeAttendancesByWeeks(DateTime week);

        List<Data.Models.EmployeeAttendance> GetEmployeeAttendancesByDays(DateTime day);

        ServiceResponse<bool> DeleteEmployeeAttendance(int id);

        ServiceResponse<bool> RecoverEmployeeAttendance(int id);

        ServiceResponse<int> CountAttendanceByMonth(DateTime month);

        ServiceResponse<int> CountAttendanceByDay(DateTime day);

        ServiceResponse<bool>
            AddAttendanceToEmployee(
                int attendanceId, int employeeId
            );

        ServiceResponse<bool>
            RemoveAttendanceOutOfEmployee(
                int attendanceId
            );
    }
}