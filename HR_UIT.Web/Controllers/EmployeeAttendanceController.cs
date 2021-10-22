using System;
using HR_UIT.Services.EmployeeAttendance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HR_UIT.Web.Serialization;
using HR_UIT.Web.ViewModels;
using System.Linq;

namespace HR_UIT.Web.Controllers
{
    [ApiController]
    public class EmployeeAttendanceController : ControllerBase
    {
        private readonly IEmployeeAttendanceService _attendanceService;
        private readonly ILogger<EmployeeAttendanceController> _logger;

        public EmployeeAttendanceController(
            ILogger<EmployeeAttendanceController> logger,
            IEmployeeAttendanceService attendanceService)
        {
            _logger = logger;
            _attendanceService = attendanceService;
        }

        /// <summary>
        /// Get All Attendances By Day ----- Admin
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        [HttpGet("/api/employee/attendance/{day}")]
        [Authorize(Policy = "Admin")]
        public ActionResult GetEmployeeAttendancesByDay(DateTime day)
        {
            _logger.LogInformation($"Getting employee attendances by {day.Date}");
            var response = _attendanceService.GetEmployeeAttendancesByDays(day);
            var attendancesModel = response
                .Select(EmployeeAttendanceMapper.MapEmployeeAttendance)
                .OrderBy(attendance => attendance.Id)
                .ToList();
            return Ok(attendancesModel);
        }

        /// <summary>
        /// Get All Attendances By Month ----- Admin
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpGet("/api/employee/attendance/{month}")]
        [Authorize(Policy = "Admin")]
        public ActionResult GetEmployeeAttendancesByMonth(DateTime month)
        {
            _logger.LogInformation($"Getting employee attendances by {month.Month}");
            var response = _attendanceService.GetEmployeeAttendancesByMonths(month);
            var attendancesModel = response
                .Select(EmployeeAttendanceMapper.MapEmployeeAttendance)
                .OrderBy(attendance => attendance.Id)
                .ToList();
            return Ok(attendancesModel);
        }

        /// <summary>
        /// Get All Attendances By Week ----- Admin
        /// </summary>
        /// <param name="week"></param>
        /// <returns></returns>
        [HttpGet("/api/employee/attendance/{week}")]
        [Authorize(Policy = "Admin")]
        public ActionResult GetEmployeeAttendancesByWeek(DateTime week)
        {
            _logger.LogInformation($"Getting employee attendances by {week}");
            var response = _attendanceService.GetEmployeeAttendancesByWeeks(week);
            var attendancesModel = response
                .Select(EmployeeAttendanceMapper.MapEmployeeAttendance)
                .OrderBy(attendance => attendance.Id)
                .ToList();
            return Ok(attendancesModel);
        }

        /// <summary>
        /// Create New Attendance <CheckIn/> ----- Both
        /// </summary>
        /// <returns></returns>
        [HttpPost("/api/employee/attendance/checkin")]
        [Authorize(Policy = "Both")]
        public ActionResult CreateNewEmployeeAttendance([FromBody] EmployeeAttendanceModel attendance)
        {
            _logger.LogInformation("Creating New Attendance");
            var response = _attendanceService
                .CreateNewEmployeeAttendance(
                    EmployeeAttendanceMapper.MapEmployeeAttendance(attendance)
                );
            return Ok(response);
        }

        /// <summary>
        /// Update Attendance <CheckOut/> ----- Both
        /// </summary>
        /// <returns></returns>
        [HttpPut("/api/employee/attendance/checkout")]
        [Authorize(Policy = "Both")]
        public ActionResult UpdateEmployee([FromBody] EmployeeAttendanceModel attendance)
        {
            _logger.LogInformation($"CheckOut Attendance {attendance.Id}");
            var response = _attendanceService.UpdateEmployeeAttendance(
                EmployeeAttendanceMapper.MapEmployeeAttendance(attendance));
            return Ok(response);
        }

        /// <summary>
        /// Delete Attendance With Given Id ----- Admin 
        /// </summary>
        /// <returns></returns>
        [HttpPatch("/api/employee/attendance/delete/{attendanceId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult DeleteEmployee(int attendanceId)
        {
            _logger.LogInformation($"Deleting Attendance {attendanceId} Complete... ");
            var response = _attendanceService.DeleteEmployeeAttendance(attendanceId);
            return Ok(response);
        }

        /// <summary>
        /// Recover Attendance With Given Id ----- Admin 
        /// </summary>
        /// <returns></returns>
        [HttpPatch("/api/employee/attendance/recover/{attendanceId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult RecoverEmployee(int attendanceId)
        {
            _logger.LogInformation($"Recovering Employee {attendanceId} Complete... ");
            var response = _attendanceService.RecoverEmployeeAttendance(attendanceId);
            return Ok(response);
        }
        
        /// <summary>
        /// Add Attendance To Employee ----- Admin
        /// </summary>
        /// <param name="attendanceId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpPatch("/api/employee/type/{employeeId}/add/{attendanceId}")]
        [Authorize(Policy = "Admin")]  
        public ActionResult UpdateRoleOfEmployee(int attendanceId, int employeeId)
        {
            _logger.LogInformation($"Update Employee {employeeId} with Type {attendanceId}");
            var response = _attendanceService.AddAttendanceToEmployee(attendanceId, employeeId);
            return Ok(response);
        }
    }
}