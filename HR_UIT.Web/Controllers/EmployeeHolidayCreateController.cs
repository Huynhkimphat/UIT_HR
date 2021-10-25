using HR_UIT.Services.HolidayCreate;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using HR_UIT.Web.Serialization;
using HR_UIT.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace HR_UIT.Web.Controllers
{
    [ApiController]
    public class EmployeeHolidayCreateController : ControllerBase
    {
        private readonly IHolidayCreateService _holidayCreateService;
        private readonly ILogger<EmployeeHolidayCreateController> _logger;

        public EmployeeHolidayCreateController(ILogger<EmployeeHolidayCreateController> logger,
            IHolidayCreateService holidayCreateService)
        {
            _logger = logger;
            _holidayCreateService = holidayCreateService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/holiday-create/all")]
        [Authorize(Policy = "Admin")]
        public ActionResult GetAllHolidayOff()
        {
            _logger.LogInformation("Getting all holidays Off");
            var holidayCreates = _holidayCreateService.GetAllHolidaysOff();
            var holidayCreateModels = holidayCreates
                .Select(HolidayCreateMapper.MapHolidayCreate)
                .OrderByDescending(holidayCreate => holidayCreate.Id)
                .ToList();
            return Ok(holidayCreateModels);
        }

        /// <summary>
        /// Get Holiday Creates By Month ----- Admin
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpGet("/api/holiday-create/{month}")]
        [Authorize(Policy = "Admin")]
        public ActionResult GetAllHolidaysOffByMonth(DateTime month)
        {
            _logger.LogInformation("Getting information of Holiday Create by selected month");
            var holidayCreateModels = _holidayCreateService.GetAllHolidaysOffByMonth(month)
                .Select(HolidayCreateMapper.MapHolidayCreate)
                .OrderByDescending(holidayCreate => holidayCreate.Id)
                .ToList();
            return Ok(holidayCreateModels);
        }

        /// <summary>
        /// Create New Holiday Off ----- Admin
        /// </summary>
        /// <param name="holidayCreate"></param>
        /// <returns></returns>
        [HttpPost("/api/holiday-create")]
        [Authorize(Policy = "Admin")]
        public ActionResult CreateHolidayOff([FromBody] HolidayCreateModel holidayCreate)
        {
            _logger.LogInformation("Creating new Holiday Off");
            var response = _holidayCreateService.CreateHolidayOff(HolidayCreateMapper.MapHolidayCreate(holidayCreate));
            return Ok(response);
        }

        /// <summary>
        /// Update Holiday Off With Given Id ----- Admin
        /// </summary>
        /// <param name="holidayCreate"></param>
        /// <param name="holidayCreateId"></param>
        /// <returns></returns>
        [HttpPut("/api/holiday-create/update/{holidayCreateId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult UpdateHolidayOff([FromBody] HolidayCreateModel holidayCreate, int holidayCreateId)
        {
            _logger.LogInformation($"Update Holiday Create {holidayCreateId}");
            var response = _holidayCreateService.UpdateHolidayOff(HolidayCreateMapper.MapHolidayCreate(holidayCreate),
                holidayCreateId);
            return Ok(response);
        }

        /// <summary>
        /// Delete Holiday Off With Given Id ----- Admin
        /// </summary>
        /// <param name="holidayCreateId"></param>
        /// <returns></returns>
        [HttpPatch("/api/holiday-create/delete/{holidayCreateId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult DeleteHolidayOff(int holidayCreateId)
        {
            _logger.LogInformation($"Deleting Holiday Off {holidayCreateId}");
            var response = _holidayCreateService.DeleteHolidayOff(holidayCreateId);
            return Ok(response);
        }

        /// <summary>
        /// Recover Holiday Off With Given Id ----- Admin
        /// </summary>
        /// <param name="holidayCreateId"></param>
        /// <returns></returns>
        [HttpPatch("/api/holiday-create/recover/{holidayCreateId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult RecoverHolidayOff(int holidayCreateId)
        {
            _logger.LogInformation($"Recovering Holiday Off {holidayCreateId}");
            var response = _holidayCreateService.RecoverHolidayOff(holidayCreateId);
            return Ok(response);
        }

        [HttpPatch("/api/holiday-create/{holidayCreateId}/add/employee/{employeeId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult AddHolidayCreateToEmployee(int employeeId, int holidayCreateId)
        {
            _logger.LogInformation($"Update Employee {employeeId} with Holiday Create {holidayCreateId}");
            var response = _holidayCreateService.AddHolidayCreateToEmployee(holidayCreateId, employeeId);
            return Ok(response);
        }

        [HttpPatch("/api/holiday-create/{holidayCreateId}/remove/employee/{employeeId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult RemoveHolidayCreateToEmployee(int employeeId, int holidayCreateId)
        {
            _logger.LogInformation($"Update Employee {employeeId} with Holiday Create {holidayCreateId}");
            var response = _holidayCreateService.RemoveHolidayCreateOutOfEmployee(holidayCreateId, employeeId);
            return Ok(response);
        }
        
        [HttpPatch("/api/holiday-create/{holidayCreateId}/add/holiday/{holidayId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult AddHolidayCreateToHoliday(int holidayId, int holidayCreateId)
        {
            _logger.LogInformation($"Update Holiday {holidayId} with Holiday Create {holidayCreateId}");
            var response = _holidayCreateService.AddHolidayCreateToHoliday(holidayCreateId, holidayId);
            return Ok(response);
        }

        [HttpPatch("/api/holiday-create/{holidayCreateId}/remove/holiday/{holidayId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult RemoveHolidayCreateToHoliday(int holidayId, int holidayCreateId)
        {
            _logger.LogInformation($"Update Holiday {holidayId} with Holiday Create {holidayCreateId}");
            var response = _holidayCreateService.RemoveHolidayCreateOutOfHoliday(holidayCreateId, holidayId);
            return Ok(response);
        }
    }
}