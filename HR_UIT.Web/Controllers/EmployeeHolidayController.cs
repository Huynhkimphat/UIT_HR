using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using HR_UIT.Services.Holiday;
using HR_UIT.Web.Serialization;
using HR_UIT.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
namespace HR_UIT.Web.Controllers
{
    [ApiController]
    public class EmployeeHolidayController : ControllerBase
    {
        private readonly IHolidayService _holidayService;
        private readonly ILogger<EmployeeHolidayController> _logger;

        public EmployeeHolidayController(ILogger<EmployeeHolidayController> logger, IHolidayService holidayService)
        {
            _logger = logger;
            _holidayService = holidayService;
        }

        /// <summary>
        /// Get All Holiday ----- Both
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/holiday/all")]
        [Authorize(Policy = "Both")]
        public ActionResult GetAllEmployee()
        {
            _logger.LogInformation("Getting holidays");
            var holidays = _holidayService.GetAllHolidays();
            var holidayModels = holidays
                .Select(HolidayMapper.MapHoliday)
                .OrderByDescending(holiday => holiday.Id)
                .ToList();
            return Ok(holidayModels);
        }

        /// <summary>
        /// Get Holiday By Given Month ----- Both
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpGet("/api/holiday/{month}")]
        [Authorize(Policy = "Both")]
        public ActionResult GetHolidaysByMonth(DateTime month)
        {
            _logger.LogInformation("Getting information of holidays by selected month");
            var holidays = _holidayService.GetHolidaysByMonth(month);
            var holidayModels = holidays
                .Select(HolidayMapper.MapHoliday)
                .OrderByDescending(holiday => holiday.Id)
                .ToList();
            return Ok(holidayModels);
        }

        /// <summary>
        /// Get Holiday By Given Id ----- Both
        /// </summary>
        /// <param name="holidayId"></param>
        /// <returns></returns>
        [HttpGet("/api/holiday/{holidayId}")]
        [Authorize(Policy = "Both")]
        public ActionResult GetHolidayById(int holidayId)
        {
            _logger.LogInformation($"Getting information of Holiday {holidayId}");
            var response = _holidayService.GetHolidayById(holidayId);
            return Ok(HolidayMapper.MapHoliday(response));
        }

        /// <summary>
        /// Create New Holiday ----- Admin
        /// </summary>
        /// <param name="holiday"></param>
        /// <returns></returns>
        [HttpPost("/api/holiday")]
        [Authorize(Policy = "Admin")]
        public ActionResult CreateNewHoliday([FromBody] HolidayModel holiday)
        {
            _logger.LogInformation("Creating New Holiday");
            var response = _holidayService.CreateHoliday(HolidayMapper.MapHoliday(holiday));
            return Ok(response);
        }

        /// <summary>
        /// Update Holiday With Given Id ----- Admin
        /// </summary>
        /// <param name="name"></param>
        /// <param name="holidayId"></param>
        /// <returns></returns>
        [HttpPut("/api/holiday/name-update/{holidayId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult UpdateHoliday([FromBody] string name, int holidayId)
        {
            _logger.LogInformation($"Update Name of Holiday {holidayId}");
            var response = _holidayService.UpdateNameOfHoliday(name, holidayId);
            return Ok(response);
        }

        /// <summary>
        /// Delete Holiday With Given Id ----- Admin
        /// </summary>
        /// <param name="holidayId"></param>
        /// <returns></returns>
        [HttpPatch("/api/holiday/delete/{holidayId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult DeleteHoliday(int holidayId)
        {
            _logger.LogInformation($"Deleting Holiday {holidayId}");
            var response = _holidayService.DeleteHoliday(holidayId);
            return Ok(response);
        }

        /// <summary>
        /// Recover Holiday With Given Id ----- Admin
        /// </summary>
        /// <param name="holidayId"></param>
        /// <returns></returns>
        [HttpPatch("/api/holiday/recover/{holidayId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult RecoverHoliday(int holidayId)
        {
            _logger.LogInformation($"Recovering Holiday {holidayId} Complete...");
            var response = _holidayService.RecoverHoliday(holidayId);
            return Ok(response);
        }
    }
}