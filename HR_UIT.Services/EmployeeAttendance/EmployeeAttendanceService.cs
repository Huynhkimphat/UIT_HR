using System;
using System.Linq;
using System.Collections.Generic;
using HR_UIT.Data;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace HR_UIT.Services.EmployeeAttendance
{
    public class EmployeeAttendanceService : IEmployeeAttendanceService
    {
        private readonly HrUitDbContext _db;

        public EmployeeAttendanceService(HrUitDbContext dbContext)
        {
            _db = dbContext;
        }

        /// <summary>
        /// Create new  Employee Attendance
        /// </summary>
        /// <param name="attendance"></param>
        /// <returns></returns>
        public ServiceResponse<Data.Models.EmployeeAttendance>
            CreateNewEmployeeAttendance(Data.Models.EmployeeAttendance attendance)
        {
            var now = DateTime.UtcNow;
            try
            {
                _db.EmployeeAttendances.Add(attendance);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.EmployeeAttendance>
                {
                    Data = attendance,
                    Time = now,
                    Message = "Save new EmployeeAttendance",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.EmployeeAttendance>
                {
                    Data = null,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

        /// <summary>
        /// Update an Employee Attendance
        /// </summary>
        /// <param name="attendance"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ServiceResponse<Data.Models.EmployeeAttendance>
            UpdateEmployeeAttendance(Data.Models.EmployeeAttendance attendance, int attendanceId)
        {
            var now = DateTime.UtcNow;
            var newEmployeeAttendance = _db.EmployeeAttendances.Find(attendanceId);
            if (newEmployeeAttendance == null)
                return new ServiceResponse<Data.Models.EmployeeAttendance>
                {
                    Data = null,
                    Time = now,
                    Message = "EmployeeAttendance to Update Not Found",
                    IsSuccess = false
                };
            try
            {
                newEmployeeAttendance.Period = attendance.Period;
                newEmployeeAttendance.ToDate = attendance.ToDate;
                newEmployeeAttendance.IsArchived = attendance.IsArchived;
                newEmployeeAttendance.IsProgressing = attendance.IsProgressing;
                newEmployeeAttendance.UpdatedOn = attendance.UpdatedOn;
                _db.EmployeeAttendances.Update(newEmployeeAttendance);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.EmployeeAttendance>
                {
                    Data = newEmployeeAttendance,
                    Time = now,
                    Message = $"EmployeeAttendance {attendanceId}  Updated!",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.EmployeeAttendance>
                {
                    Data = null,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

        /// <summary>
        /// Get a list of Employee Attendance by given month from database
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Data.Models.EmployeeAttendance> GetEmployeeAttendancesByMonths(DateTime month)
        {
            return _db.EmployeeAttendances
                .Where(e => e.FromDate.Month == month.Month
                            && e.FromDate.Year == month.Year)
                .OrderBy(employeeAttendance => employeeAttendance.Id)
                .ToList();
        }

        /// <summary>
        /// Get a list of Employee Attendance by given week from database
        /// </summary>
        /// <param name="week"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Data.Models.EmployeeAttendance> GetEmployeeAttendancesByWeeks(DateTime week)
        {
            var startOfWeek = week;
            while (startOfWeek.DayOfWeek != DayOfWeek.Monday)
                startOfWeek = startOfWeek.AddDays(-1);
            var endOfWeek = startOfWeek.AddDays(7);

            var attendances = new List<Data.Models.EmployeeAttendance>();

            while (startOfWeek <= endOfWeek)
            {
                attendances.AddRange(GetEmployeeAttendancesByDays(startOfWeek));
                startOfWeek = startOfWeek.AddDays(1);
            }

            return attendances;
        }

        /// <summary>
        /// Get a list of Employee Attendance by given day from database
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public List<Data.Models.EmployeeAttendance> GetEmployeeAttendancesByDays(DateTime day)
        {
            return _db.EmployeeAttendances
                .Where(e => e.FromDate.Day == day.Day
                            && e.FromDate.Month == day.Month
                            && e.FromDate.Year == day.Year)
                .OrderBy(employeeAttendance => employeeAttendance.Id)
                .ToList();
        }

        /// <summary>
        /// Delete an Employee Attendance by given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponse<bool> DeleteEmployeeAttendance(int id)
        {
            var now = DateTime.UtcNow;
            var employeeAttendance = _db.EmployeeAttendances.Find(id);
            if (employeeAttendance == null)
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "EmployeeAttendance to archive not found",
                    IsSuccess = false
                };
            try
            {
                employeeAttendance.IsArchived = true;
                employeeAttendance.UpdatedOn = now;
                _db.EmployeeAttendances.Update(employeeAttendance);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "EmployeeAttendance archived",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

        /// <summary>
        /// Recover an Employee Attendance by given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ServiceResponse<bool> RecoverEmployeeAttendance(int id)
        {
            var now = DateTime.UtcNow;
            var employeeAttendance = _db.EmployeeAttendances.Find(id);
            if (employeeAttendance == null)
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "EmployeeAttendance to recover not found",
                    IsSuccess = false
                };
            try
            {
                employeeAttendance.IsArchived = false;
                employeeAttendance.UpdatedOn = now;
                _db.EmployeeAttendances.Update(employeeAttendance);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "EmployeeAttendance recovered",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

        /// <summary>
        /// Count Employee Attendance Period by given Month
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public ServiceResponse<int> CountAttendanceByMonth(DateTime month)
        {
            var now = DateTime.UtcNow;
            var Attendance = _db.EmployeeAttendances
                .Where(e => e.FromDate.Month == month.Month
                            && e.FromDate.Year == month.Year).ToList();

            var count = 0;

            count = Attendance.Aggregate(count, (current, i) => current+ i.Period);
            var cul = CultureInfo.CreateSpecificCulture("en-US");

            return new ServiceResponse<int>
            {
                Data = count,
                Time = now,
                Message = $"{count} Periods in {month.ToString("MMMM dd, yyyy", cul)}",
                IsSuccess = true
            };
        }

        /// <summary>
        /// Count Employee Attendance Period by given day
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public ServiceResponse<int> CountAttendanceByDay(DateTime day)
        {
            var now = DateTime.UtcNow;

            var Attendance = _db.EmployeeAttendances
                .Where(e => e.FromDate.Day == day.Day
                            && e.FromDate.Month == day.Month
                            && e.FromDate.Year == day.Year).ToList();

            var count = 0;
            count = Attendance.Aggregate(count, (current, i) => current + i.Period);

            var cul = CultureInfo.CreateSpecificCulture("en-US");

            return new ServiceResponse<int>
            {
                Data = count,
                Time = now,
                Message = $"{count} Periods in {day.ToString("Y", cul)}",
                IsSuccess = true
            };
        }

    public ServiceResponse<bool> AddAttendanceToEmployee(int attendanceId, int employeeId)
        {
            var now = DateTime.UtcNow;
            var currentEmployee = _db.Employees.Find(employeeId);
            var currentAttendance = _db.EmployeeAttendances.Find(attendanceId);
            ;
            if (currentAttendance == null || currentEmployee == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "Employee To Update or Attendance To Update Not Found",
                    IsSuccess = false
                };
            }
            if (currentAttendance.IsExisted)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "Attendance Already Has Linked To Another Employee",
                    IsSuccess = false
                };
            }

            try
            {
                currentEmployee.EmployeeAttendances ??= new List<Data.Models.EmployeeAttendance>();
                currentAttendance.IsExisted = true;
                currentEmployee.EmployeeAttendances.Add(currentAttendance);
                
                _db.Update(currentEmployee);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "Attendance To Update Completed",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

        public ServiceResponse<bool> RemoveAttendanceOutOfEmployee(int attendanceId)
        {
            throw new NotImplementedException();
        }
    }
}