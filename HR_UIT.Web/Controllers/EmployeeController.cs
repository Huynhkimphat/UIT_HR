using System.Linq;
using HR_UIT.Services.Employee;
using HR_UIT.Web.Serialization;
using HR_UIT.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("/api/employee/all")]
        public ActionResult GetAllEmployee()
        {
            _logger.LogInformation("Getting employees");
            var employees = _employeeService.GetAllEmployees();
            var employeeModels = employees
                .Select(employee => new EmployeeModel
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    DateOfBirth = employee.DateOfBirth,
                    PhoneNumber = employee.PhoneNumber,
                    IdentityCard = employee.IdentityCard,
                    PrimaryAddress = EmployeeAddressMapper.MapEmployeeAddress(employee.PrimaryAddress),
                    CreatedOn = employee.CreatedOn,
                    UpdatedOn = employee.UpdatedOn,
                    IsArchived=employee.IsArchived,
                })
                .OrderByDescending(employee => employee.Id)
                .ToList();
            return Ok(employeeModels);
        }
        
        [HttpGet("/api/employee")]
        public ActionResult GetAllAvailableEmployees()
        {
            _logger.LogInformation("Getting employees visible (isArchived = false)");
            var employees = _employeeService.GetAllEmployeesVisible(); 
            var employeeModels = employees
                .Select(employee => new EmployeeModel
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    DateOfBirth = employee.DateOfBirth,
                    PhoneNumber = employee.PhoneNumber,
                    IdentityCard = employee.IdentityCard,
                    PrimaryAddress = EmployeeAddressMapper.MapEmployeeAddress(employee.PrimaryAddress),
                    CreatedOn = employee.CreatedOn,
                    UpdatedOn = employee.UpdatedOn,
                    IsArchived=employee.IsArchived,
                })
                .OrderByDescending(employee => employee.Id)
                .ToList();
            return Ok(employeeModels);
        }
        
        [HttpPatch("/api/employee/delete/{employeeId}")]
        public ActionResult DeleteEmployee(int employeeId)
        {
            _logger.LogInformation($"Deleting Employee {employeeId} Complete... ");
            var response = _employeeService.DeleteEmployee(employeeId);
            return Ok(response);
        }

        [HttpGet("/api/employee/{employeeId}")]
        public ActionResult GetEmployeeById(int employeeId)
        {
            _logger.LogInformation($"Getting information of Employee {employeeId} Complete... ");
            var response = _employeeService.GetEmployeeById(employeeId);
            return Ok(response);
        }
    }
}