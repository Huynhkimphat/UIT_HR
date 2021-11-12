using System.Linq;
using HR_UIT.Data.Models;
using HR_UIT.Services.Employee;
using HR_UIT.Services.HolidayCreate;
using HR_UIT.Web.Serialization;
using HR_UIT.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace HR_UIT.Web.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }
        
        /// <summary>
        /// Get All Employee ----- Admin
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/employee/all")]
        [Authorize(Policy = "Admin")]
        public ActionResult GetAllEmployee()
        {
            _logger.LogInformation("Getting employees");
            var employees = _employeeService.GetAllEmployees();
            var employeeModels = employees
                .Select(EmployeeMapper.MapEmployee)
                .OrderByDescending(employee => employee.Id)
                .ToList();
            return Ok(employeeModels);
        }
        
        /// <summary>
        /// Get All Available Employee ----- Admin
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/employee")]
        [Authorize(Policy = "Admin")]
        public ActionResult GetAllAvailableEmployees()
        {
            _logger.LogInformation("Getting employees visible (isArchived = false)");
            var employees = _employeeService.GetAllEmployeesVisible();
            var employeeModels = employees
                .Select(EmployeeMapper.MapEmployee)
                .OrderByDescending(employee => employee.Id)
                .ToList();
            return Ok(employeeModels);
        }

        /// <summary>
        /// Create New Employee ----- Admin
        /// </summary>
        /// <returns></returns>
        [HttpPost("/api/employee")]
        // [Authorize(Policy = "Admin")]
        public ActionResult CreateNewEmployee([FromBody] EmployeeModel employee)
        {
            _logger.LogInformation("Creating New Employee");
            var response = _employeeService.CreateEmployee(EmployeeMapper.MapEmployee(employee));
            return Ok(response);
        }
        
        /// <summary>
        /// Update Employee By Id ----- Both
        /// </summary>
        /// <returns></returns>
        [HttpPatch("/api/employee/update/{employeeId}")]
        [Authorize(Policy = "Both")]
        public ActionResult UpdateEmployee([FromBody] EmployeeModel employee, int employeeId)
        {
            _logger.LogInformation($"Update Employee {employeeId}");
            var response = _employeeService.UpdateEmployee(EmployeeMapper.MapEmployee(employee), employeeId);
            return Ok(response);
        }
        
        /// <summary>
        /// Get Employee By Given Id ----- Admin And Staff  
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpGet("/api/employee/{employeeId}")]
        [Authorize(Policy = "Both")]
        public ActionResult GetEmployeeById(int employeeId)
        {
            _logger.LogInformation($"Getting information of Employee {employeeId} Complete... ");
            var response = _employeeService.GetEmployeeById(employeeId);
            return Ok(EmployeeMapper.MapEmployee(response));
        }

        /// <summary>
        /// Delete Employee With Given Id ----- Admin 
        /// </summary>
        /// <returns></returns>
        [HttpPatch("/api/employee/delete/{employeeId}")]
        // [Authorize(Policy = "Admin")]
        public ActionResult DeleteEmployee(int employeeId)
        {
            _logger.LogInformation($"Deleting Employee {employeeId} Complete... ");
            var response = _employeeService.DeleteEmployee(employeeId);
            return Ok(response);
        }
        
        /// <summary>
        /// Recover Employee With Given Id ----- Admin 
        /// </summary>
        /// <returns></returns>
        [HttpPatch("/api/employee/recover/{employeeId}")]
        // [Authorize(Policy = "Admin")]
        public ActionResult RecoverEmployee(int employeeId)
        {
            _logger.LogInformation($"Recovering Employee {employeeId} Complete... ");
            var response = _employeeService.RecoverEmployee(employeeId);
            return Ok(response);
        }
    }
}