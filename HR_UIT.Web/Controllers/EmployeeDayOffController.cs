using Microsoft.AspNetCore.Mvc;
using System.Linq;
using HR_UIT.Data.Models;
using HR_UIT.Services.EmployeeDayOffService;
using HR_UIT.Services.HolidayCreate;
using HR_UIT.Web.Serialization;
using HR_UIT.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
namespace HR_UIT.Web.Controllers
{
    [ApiController]
    public class EmployeeDayOffController : ControllerBase
    {
        private readonly IEmployeeDayOffService _employeeDayOffService;
        private readonly ILogger<EmployeeDayOffController> _logger;

        public EmployeeDayOffController(ILogger<EmployeeDayOffController> logger,
            IEmployeeDayOffService employeeDayOffService)
        {
            _logger = logger;
            _employeeDayOffService = employeeDayOffService;
        }

        /// <summary>
        /// Create New Employee Day Off ----- Admin
        /// </summary>
        /// <param name="employeeDayOff"></param>
        /// <returns></returns>
        [HttpPost("/api/employee/dayOff")]
        [Authorize(Policy = "Admin")]
        public ActionResult CreateNewEmployeeDayOff([FromBody] EmployeeDayOffModel employeeDayOff)
        {
            _logger.LogInformation("Creating New Employee Day Off");
            var response =
                _employeeDayOffService.CreateNewEmployeeDayOff(EmployeeDayOffMapper.MapEmployeeDayOff(employeeDayOff));
            return Ok(response);
        }

        /// <summary>
        /// Update Employee Day Off ----- Admin
        /// </summary>
        /// <param name="employeeDayOff"></param>
        /// <param name="dayOffId"></param>
        /// <returns></returns>
        [HttpPut("/api/employee/dayOff/update/{dayOffId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult UpdateEmployeeDayOff([FromBody] EmployeeDayOffModel employeeDayOff, int dayOffId)
        {
            _logger.LogInformation($"Update Employee Day Off {dayOffId}");
            var response =
                _employeeDayOffService.UpdateEmployeeDayOff(EmployeeDayOffMapper.MapEmployeeDayOff(employeeDayOff),
                    dayOffId);
            return Ok(response);
        }

        /// <summary>
        /// Get All Employee Day Off ----- Admin
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/employee/dayOff/all")]
        [Authorize(Policy = "Admin")]
        public ActionResult GetAllEmployeeDayOff()
        {
            _logger.LogInformation("Getting employee Days Off");
            var employeeDaysOff = _employeeDayOffService.GetAllEmployeeDayOff()
                .Select(EmployeeDayOffMapper.MapEmployeeDayOff)
                .OrderByDescending(employeeDayOff => employeeDayOff.Id)
                .ToList();
            return Ok(employeeDaysOff);
        }

        /// <summary>
        /// Get Employee Day Of By Given Id ----- Both
        /// </summary>
        /// <param name="dayOffId"></param>
        /// <returns></returns>
        [HttpGet("api/employee/dayOff/{dayOffId}")]
        [Authorize(Policy = "Both")]
        public ActionResult GetEmployeeDayOffById(int dayOffId)
        {
            _logger.LogInformation($"Getting information of Day Off {dayOffId}");
            var response = _employeeDayOffService.GetEmployeeDayOffById(dayOffId);
            return Ok(EmployeeDayOffMapper.MapEmployeeDayOff(response));
        }

        /// <summary>
        /// Delete Employee Day Off ----- Admin
        /// </summary>
        /// <param name="dayOffId"></param>
        /// <returns></returns>
        [HttpPatch("/api/employee/dayOff/delete/{dayOffId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult DeleteEmployeeDayOff(int dayOffId)
        {
            _logger.LogInformation($"Deleting Employee Day Off {dayOffId}");
            var response = _employeeDayOffService.DeleteEmployeeDayOff(dayOffId);
            return Ok(response);
        }

        /// <summary>
        /// Recover Employee Day Of ----- Admin
        /// </summary>
        /// <param name="dayOffId"></param>
        /// <returns></returns>
        [HttpPatch("/api/employee/dayOff/recover/{dayOffId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult RecoverEmployeeDayOff(int dayOffId)
        {
            _logger.LogInformation($"Recovering Employee Day Off {dayOffId}");
            var response = _employeeDayOffService.RecoverEmployeeDayOff(dayOffId);
            return Ok(response);
        }
    }
}