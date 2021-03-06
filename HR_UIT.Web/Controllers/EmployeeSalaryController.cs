using HR_UIT.Data.Models;
using System.Linq;
using HR_UIT.Services.Salary;
using HR_UIT.Web.Serialization;
using HR_UIT.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

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
            var response =
                _salaryService.UpdateEmployeeSalary(EmployeeSalaryMapper.MapEmployeeSalary(salary), salaryId);
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
            var salaries = _salaryService.GetEmployeeSalaryByYearMonth(year, month);
            var salaryModels = salaries
                .Select(EmployeeSalaryMapper.MapEmployeeSalary)
                .OrderByDescending(salary => salary.Id)
                .ToList();
            return Ok(salaryModels);
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
        /// Recovering Employee Salary ----- Admin
        /// </summary>
        /// <param name="salaryId"></param>
        /// <returns></returns>
        [HttpPatch("/api/salary/recover/{salaryId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult RecoverEmployeeSalary(int salaryId)
        {
            _logger.LogInformation($"Recover Employee Salary Id: {salaryId}");
            var response = _salaryService.RecoverSalary(salaryId);
            return Ok(response);
        }

        /// <summary>
        /// Check Salary By Employee ----- Staff 
        /// </summary>
        /// <param name="salaryId"></param>
        /// <returns></returns>
        [HttpPatch("/api/salary/checked/{salaryId}")]
        [Authorize(Policy = "Staff")]
        public ActionResult CheckEmployeeSalary(int salaryId)
        {
            _logger.LogInformation($"Checking employee salary Id: {salaryId}");
            var response = _salaryService.IsCheckedSalary(salaryId);
            return Ok(response);
        }


        /// <summary>
        /// UnCheck Salary By Employee ----- Staff 
        /// </summary>
        /// <param name="salaryId"></param>
        /// <returns></returns>
        [HttpPatch("/api/salary/unchecked/{salaryId}")]
        [Authorize(Policy = "Staff")]
        public ActionResult UnCheckEmployeeSalary(int salaryId)
        {
            _logger.LogInformation($"UnChecking employee salary Id: {salaryId}");
            var response = _salaryService.IsUnCheckedSalary(salaryId);
            return Ok(response);
        }

        /// <summary>
        /// Receiving Salary By Given Id ----- Admin
        /// </summary>
        /// <param name="salaryId"></param>
        /// <returns></returns>
        [HttpPatch("/api/salary/received/{salaryId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult ReceiveEmployeeSalary(int salaryId)
        {
            _logger.LogInformation($"Receiving employee salary Id: {salaryId}");
            var response = _salaryService.IsReceivedSalary(salaryId);
            return Ok(response);
        }

        /// <summary>
        /// UnReceiving Salary By Given Id ----- Admin
        /// </summary>
        /// <param name="salaryId"></param>
        /// <returns></returns>
        [HttpPatch("/api/salary/unreceived/{salaryId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult UnReceivedEmployeeSalary(int salaryId)
        {
            _logger.LogInformation($"UnReceiving employee salary Id: {salaryId}");
            var response = _salaryService.IsUnReceivedSalary(salaryId);
            return Ok(response);
        }

        /// <summary>
        /// Add Salary To Employee With Given Id ----- Admin
        /// </summary>
        /// <param name="salaryId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpPatch("/api/employee/salary/{salaryId}/add/{employeeId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult AddSalaryToEmployee(int salaryId, int employeeId)
        {
            _logger.LogInformation($"Update Employee {employeeId} with Salary {salaryId}");
            var response = _salaryService.AddSalaryToEmployee(salaryId, employeeId);
            return Ok(response);
        }

        /// <summary>
        /// Remove Salary Out Of Employee With Given Id ----- Admin
        /// </summary>
        /// <param name="salaryId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpPatch("/api/employee/salary/{salaryId}/remove/{employeeId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult RemoveRoleOfEmployee(int salaryId,int employeeId)
        {
            _logger.LogInformation($"Remove Employee {employeeId} with Salary {salaryId}");
            var response = _salaryService.RemoveSalaryOutOfEmployee(salaryId,employeeId);
            return Ok(response);
        }
    }
}