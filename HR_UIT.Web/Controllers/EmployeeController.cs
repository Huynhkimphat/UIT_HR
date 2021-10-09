using System.Linq;
using HR_UIT.Services.Employee;
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
        /// Admin authorize
        /// Get all employee
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
        /// Admin authorize
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
        /// Admin authorize
        /// </summary>
        /// <returns></returns>
        [HttpPost("/api/employee")]
        [Authorize(Policy = "Admin")]
        public ActionResult CreateNewEmployee([FromBody] EmployeeModel employee)
        {
            _logger.LogInformation("Creating New Employee");
            var response = _employeeService.CreateEmployee(EmployeeMapper.MapEmployee(employee));
            return Ok(response);
        }
        
        /// <summary>
        /// Admin authorize
        /// </summary>
        /// <returns></returns>
        [HttpPut("/api/employee/update/{employeeId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult UpdateEmployee([FromBody] EmployeeModel employee, int employeeId)
        {
            _logger.LogInformation($"Update Employee {employeeId}");
            var response = _employeeService.UpdateEmployee(EmployeeMapper.MapEmployee(employee), employeeId);
            return Ok(response);
        }
        
        /// <summary>
        /// Admin, Staff authorize
        /// Return Employee By Given Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpGet("/api/employee/{employeeId}")]
        [Authorize(Policy = "Both")]
        public ActionResult GetEmployeeById(int employeeId)
        {
            _logger.LogInformation($"Getting information of Employee {employeeId} Complete... ");
            var response = _employeeService.GetEmployeeById(employeeId);
            return Ok(response);
        }

        /// <summary>
        /// Admin authorize
        /// </summary>
        /// <returns></returns>
        [HttpPatch("/api/employee/delete/{employeeId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult DeleteEmployee(int employeeId)
        {
            _logger.LogInformation($"Deleting Employee {employeeId} Complete... ");
            var response = _employeeService.DeleteEmployee(employeeId);
            return Ok(response);
        }
        
        /// <summary>
        /// Admin authorize
        /// </summary>
        /// <returns></returns>
        [HttpPatch("/api/employee/recover/{employeeId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult RecoverEmployee(int employeeId)
        {
            _logger.LogInformation($"Recovering Employee {employeeId} Complete... ");
            var response = _employeeService.RecoverEmployee(employeeId);
            return Ok(response);
        }
    }
}