using System;
using System.Linq;
using System.Collections.Generic;
using HR_UIT.Data;
using System.Globalization;
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
            UpdateEmployeeAttendance(Data.Models.EmployeeAttendance attendance)
        {
            var now = DateTime.UtcNow;
            var newEmployeeAttendance = _db.EmployeeAttendances.Find(attendance);
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
                newEmployeeAttendance.FromDate = attendance.FromDate;
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
                    Message = $"EmployeeAttendance {newEmployeeAttendance.Id}  Updated!",
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

            List<Data.Models.EmployeeAttendance> attendances = new List<Data.Models.EmployeeAttendance>();
            
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
        public ServiceResponse<TimeSpan> CountAttendanceByMonth(DateTime month)
        {
            var now = DateTime.UtcNow;
            List<Data.Models.EmployeeAttendance> Attendance = _db.EmployeeAttendances
                .Where(e => e.FromDate.Month == month.Month
                            && e.FromDate.Year == month.Year).ToList();

            TimeSpan count = new TimeSpan();
            
            foreach (var i in Attendance)
            {
                count = count.Add(i.Period);
            }
            CultureInfo cul = CultureInfo.CreateSpecificCulture("en-US");
            
            return new ServiceResponse<TimeSpan>
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
        public ServiceResponse<TimeSpan> CountAttendanceByDay(DateTime day)
        {
            var now = DateTime.UtcNow;
            
            List<Data.Models.EmployeeAttendance> Attendance = _db.EmployeeAttendances
                .Where(e => e.FromDate.Day == day.Day
                            && e.FromDate.Month == day.Month
                            && e.FromDate.Year == day.Year).ToList();

            TimeSpan count = new TimeSpan();
            foreach (var i in Attendance)
            {
                count = count.Add(i.Period);
            }
            
            CultureInfo cul = CultureInfo.CreateSpecificCulture("en-US");
            
            return new ServiceResponse<TimeSpan>
            {
                Data = count,
                Time = now,
                Message = $"{count} Periods in {day.ToString("Y", cul)}",
                IsSuccess = true
            };
        }
    }
}