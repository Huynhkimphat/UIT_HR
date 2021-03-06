using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using HR_UIT.Data.Models;
using HR_UIT.Services.EmployeeDayOff_Letter;
using HR_UIT.Services.HolidayCreate;
using HR_UIT.Web.Serialization;
using HR_UIT.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace HR_UIT.Web.Controllers
{
    [ApiController]
    public class EmployeeDayOffLetterController : ControllerBase
    {
        private readonly IEmployeeDayOffLetterService _dayOffLetterService;
        private readonly ILogger<EmployeeDayOffLetterController> _logger;

        public EmployeeDayOffLetterController(ILogger<EmployeeDayOffLetterController> logger,
            IEmployeeDayOffLetterService dayOffLetterService)
        {
            _logger = logger;
            _dayOffLetterService = dayOffLetterService;
        }

        /// <summary>
        /// Create New Employee Day Off Letter ----- Both
        /// </summary>
        /// <param name="dayOffLetter"></param>
        /// <returns></returns>
        [HttpPost("/api/employee/day-off-letter")]
        [Authorize(Policy = "Both")]
        public ActionResult CreateNewEmployeeDayOffLetter([FromBody] EmployeeDayOffLetterModel dayOffLetter)
        {
            _logger.LogInformation("Creating New Employee Day Off Letter");
            var response =
                _dayOffLetterService.CreateNewEmployeeDayOffLetter(
                    EmployeeDayOffLetterMapper.MapEmployeeDayOffLetter(dayOffLetter));
            return Ok(response);
        }

        /// <summary>
        /// Update Employee Day Off Letter ----- Both
        /// </summary>
        /// <param name="dayOffLetter"></param>
        /// <param name="dayOffLetterId"></param>
        /// <returns></returns>
        [HttpPut("/api/employee/day-off-letter/update/{dayOffLetterId}")]
        [Authorize(Policy = "Both")]
        public ActionResult UpdateEmployeeDayOffLetter([FromBody] EmployeeDayOffLetterModel dayOffLetter,
            int dayOffLetterId)
        {
            _logger.LogInformation($"Update Employee Day Off Letter {dayOffLetterId}");
            var response =
                _dayOffLetterService.UpdateEmployeeDayOffLetter(
                    EmployeeDayOffLetterMapper.MapEmployeeDayOffLetter(dayOffLetter), dayOffLetterId);
            return Ok(response);
        }

        /// <summary>
        /// Get All Employee Day Off Letter ----- Admin
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/employee/day-off-letter/all")]
        [Authorize(Policy = "Admin")]
        public ActionResult GetAllEmployeeDayOffLetter()
        {
            _logger.LogInformation("Get all Employee Day Off Letter");
            var dayOffLetters = _dayOffLetterService.GetAllEmployeeDayOffLetter()
                .Select(EmployeeDayOffLetterMapper.MapEmployeeDayOffLetter)
                .OrderByDescending(dayOffLetter => dayOffLetter.Id)
                .ToList();
            return Ok(dayOffLetters);
        }

        /// <summary>
        /// Get All Employee Day Off Letter By Given Day ----- Admin
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        [HttpGet("/api/employee/day-off-letter/day/{day}")]
        [Authorize(Policy = "Admin")]
        public ActionResult GetAllEmployeeDayOffLetterByDay(DateTime day)
        {
            _logger.LogInformation($"Getting Employee Day Off Letter day: {day.Day}");
            var dayOffLetters = _dayOffLetterService.GetAllEmployeeDayOffLetterByDay(day)
                .Select(EmployeeDayOffLetterMapper.MapEmployeeDayOffLetter)
                .OrderByDescending(dayOffLetter => dayOffLetter.Id)
                .ToList();
            return Ok(dayOffLetters);
        }

        /// <summary>
        /// Get All Employee Day Off Letter By Given Month ----- Admin
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpGet("/api/employee/day-off-letter/month/{month}")]
        [Authorize(Policy = "Admin")]
        public ActionResult GetAllEmployeeDayOffLetterByMonth(DateTime month)
        {
            _logger.LogInformation($"Getting Employee Day Off Letter month: {month.Month}");
            var dayOffLetters = _dayOffLetterService.GetAllEmployeeDayOffLetterByMonth(month)
                .Select(EmployeeDayOffLetterMapper.MapEmployeeDayOffLetter)
                .OrderByDescending(dayOffLetter => dayOffLetter.Id)
                .ToList();
            return Ok(dayOffLetters);
        }

        /// <summary>
        /// Get All Employee Day Off Letter By Given Week ----- Admin
        /// </summary>
        /// <param name="week"></param>
        /// <returns></returns>
        [HttpGet("/api/employee/day-off-letter/week/{week}")]
        [Authorize(Policy = "Admin")]
        public ActionResult GetAllEmployeeDayOffLetterByWeek(DateTime week)
        {
            _logger.LogInformation($"Getting Employee Day Off Letter week in: {week.Date}");
            var dayOffLetters = _dayOffLetterService.GetAllEmployeeDayOffLetterByWeek(week)
                .Select(EmployeeDayOffLetterMapper.MapEmployeeDayOffLetter)
                .OrderByDescending(dayOffLetter => dayOffLetter.Id)
                .ToList();
            return Ok(dayOffLetters);
        }

        /// <summary>
        /// Approve Employee Day Off Letter ----- Admin
        /// </summary>
        /// <param name="dayOffLetterId"></param>
        /// <returns></returns>
        [HttpPatch("/api/employee/day-off-letter/{dayOffLetterId}/approved")]
        [Authorize(Policy = "Admin")]
        public ActionResult ApproveEmployeeDayOffLetter(int dayOffLetterId)
        {
            _logger.LogInformation($"Approving Employee Day Off Letter {dayOffLetterId}");
            var response = _dayOffLetterService.ApproveEmployeeDayOffLetter(dayOffLetterId);
            return Ok(response);
        }

        /// <summary>
        /// Delete Employee Day Off Letter ----- Both
        /// </summary>
        /// <param name="dayOffLetterId"></param>
        /// <returns></returns>
        [HttpPatch("/api/employee/day-off-letter/delete/{dayOffLetterId}")]
        [Authorize(Policy = "Both")]
        public ActionResult DeleteEmployeeDayOffLetter(int dayOffLetterId)
        {
            _logger.LogInformation($"Deleting Employee Day Off Letter {dayOffLetterId}");
            var response = _dayOffLetterService.DeleteEmployeeDayOffLetter(dayOffLetterId);
            return Ok(response);
        }

        /// <summary>
        /// Recover Employee Day Off Letter ----- Both
        /// </summary>
        /// <param name="dayOffLetterId"></param>
        /// <returns></returns>
        [HttpPatch("/api/employee/day-off-letter/recover/{dayOffLetterId}")]
        [Authorize(Policy = "Both")]
        public ActionResult RecoverEmployeeDayOffLetter(int dayOffLetterId)
        {
            _logger.LogInformation($"Recovering employee Day Off Letter {dayOffLetterId}");
            var response = _dayOffLetterService.RecoverEmployeeDayOffLetter(dayOffLetterId);
            return Ok(response);
        }

        /// <summary>
        /// Add DayOffLetter To Employee ----- Both
        /// </summary>
        /// <param name="dayOffLetterId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpPatch("/api/day-off-letter/{dayOffLetterId}/add/employee/{employeeId}")]
        [Authorize(Policy = "Both")]
        public ActionResult AddDayOffLetterToEmployee(int dayOffLetterId, int employeeId)
        {
            _logger.LogInformation($"Update DayOff Letter {dayOffLetterId} with Employee {employeeId}");
            var response = _dayOffLetterService.AddDayOffLetterToEmployee(dayOffLetterId, employeeId);
            return Ok(response);
        }

        /// <summary>
        /// Remove DayOffLetter Out Of Employee ----- Both
        /// </summary>
        /// <param name="dayOffLetterId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpPatch("/api/day-off-letter/{dayOffLetterId}/remove/employee/{employeeId}")]
        [Authorize(Policy = "Both")]
        public ActionResult RemoveDayOffLetterOutOfEmployee(int dayOffLetterId, int employeeId)
        {
            _logger.LogInformation($"Update DayOff Letter {dayOffLetterId} with Employee {employeeId}");
            var response = _dayOffLetterService.RemoveDayOffLetterOutOfEmployee(dayOffLetterId, employeeId);
            return Ok(response);
        }


    }
}