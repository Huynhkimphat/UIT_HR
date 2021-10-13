using HR_UIT.Data.Models;
using System.Linq;
using HR_UIT.Services.Salary;
using HR_UIT.Web.Serialization;
using HR_UIT.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace HR_UIT.Web.Controllers
{
    [ApiController]
    public class EmployeeSalaryController : ControllerBase
    {
        private readonly ISalaryService _salaryService;
        private readonly ILogger<EmployeeSalaryController> _logger;

        public EmployeeSalaryController(ILogger<EmployeeSalaryController> logger, ISalaryService salaryService)
        {
            _logger = logger;
            _salaryService = salaryService;
        }

        /// <summary>
        /// Creating New Employee Salary ----- Admin 
        /// </summary>
        /// <param name="salary"></param>
        /// <returns></returns>
        [HttpPost("/api/salary")]
        [Authorize(Policy = "Admin")]
        public ActionResult CreateNewEmployeeSalary([FromBody] EmployeeSalaryModel salary)
        {
            _logger.LogInformation("Creating New Employee Salary");
            var response = _salaryService.CreateEmployeeSalary(EmployeeSalaryMapper.MapEmployeeSalary(salary));
            return Ok(response);
        }

        /// <summary>
        /// Update employee salary ----- Admin
        /// </summary>
        /// <param name="salary"></param>
        /// <param name="salaryId"></param>
        /// <returns></returns>
        [HttpPut("/api/salary/update/{salaryId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult UpdateEmployeeSalary([FromBody] EmployeeSalaryModel salary, int salaryId)
        {
            _logger.LogInformation($"Update Employee Salary Id: {salaryId}");
            var response = _salaryService.UpdateEmployeeSalary(EmployeeSalaryMapper.MapEmployeeSalary(salary), salaryId);
            return Ok(response);
        }

        /// <summary>
        /// Get Employee Salary By Given Id ----- Admin And Staff
        /// </summary>
        /// <param name="salaryId"></param>
        /// <returns></returns>
        [HttpGet("/api/salary/{salaryId}")]
        [Authorize(Policy = "Both")]
        public ActionResult GetEmployeeSalaryById(int salaryId)
        {
            _logger.LogInformation($"Getting information of Employee Salary Id {salaryId}");
            var response = _salaryService.GetEmployeeSalaryById(salaryId);
            return Ok(EmployeeSalaryMapper.MapEmployeeSalary(response));
        }
        
        /// <summary>
        /// Get Employee Salary By Year And Month ----- Admin And Staff
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        [HttpGet("/api/salary/{year}/{month}")]
        [Authorize(Policy = "Both")]
        public ActionResult GetEmployeeSalaryByYearMonth(int year, int month)
        {
            _logger.LogInformation("Getting Employee Salary by Year and Month");
            var response = _salaryService.GetEmployeeSalaryByYearMonth(year, month);
            return Ok(EmployeeSalaryMapper.MapEmployeeSalary(response));
        }

        /// <summary>
        /// Deleting Employee Salary ----- Admin
        /// </summary>
        /// <param name="salaryId"></param>
        /// <returns></returns>
        [HttpPatch("/api/salary/delete/{salaryId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult DeleteEmployeeSalary(int salaryId)
        {
            _logger.LogInformation($"Deleting Employee Salary Id: {salaryId}");
            var response = _salaryService.DeleteSalary(salaryId);
            return Ok(response);
        }
        
        /// <summary>
        /// Check Salary By Employee ----- Staff 
        /// </summary>
        /// <param name="salaryId"></param>
        /// <returns></returns>
        [HttpPatch("/api/salary/check/{salaryId}")]
        [Authorize(Policy = "Staff")]
        public ActionResult CheckEmployeeSalary(int salaryId)
        {
            _logger.LogInformation($"Checking employee salary Id: {salaryId}");
            var response = _salaryService.CheckSalary(salaryId);
            return Ok(response);
        }
        
        /// <summary>
        /// Check if salary received ----- Admin
        /// </summary>
        /// <param name="salaryId"></param>
        /// <returns></returns>
        [HttpPatch("/api/salary/receive/{salaryId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult ReceiveEmployeeSalary(int salaryId)
        {
            _logger.LogInformation($"Checking employee salary Id: {salaryId}");
            var response = _salaryService.ReceiveSalary(salaryId);
            return Ok(response);
        }
    }
}