﻿using System.Linq;
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
        
        /// <summary>
        /// Get all employee
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/employee/all")]
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

        [HttpGet("/api/employee")]
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

        [HttpPost("/api/employee")]
        public ActionResult CreateNewEmployee([FromBody] EmployeeModel employee)
        {
            _logger.LogInformation("Creating New Employee");
            var response = _employeeService.CreateEmployee(EmployeeMapper.MapEmployee(employee));
            return Ok(response);
        }

        [HttpPut("/api/employee/update/{employeeId}")]
        public ActionResult UpdateEmployee([FromBody] EmployeeModel employee, int employeeId)
        {
            _logger.LogInformation($"Update Employee {employeeId}");
            var response = _employeeService.UpdateEmployee(EmployeeMapper.MapEmployee(employee), employeeId);
            return Ok(response);
        }

        /// <summary>
        /// Return Employee By Given Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpGet("/api/employee/{employeeId}")]
        public ActionResult GetEmployeeById(int employeeId)
        {
            _logger.LogInformation($"Getting information of Employee {employeeId} Complete... ");
            var response = _employeeService.GetEmployeeById(employeeId);
            return Ok(response);
        }


        [HttpPatch("/api/employee/delete/{employeeId}")]
        public ActionResult DeleteEmployee(int employeeId)
        {
            _logger.LogInformation($"Deleting Employee {employeeId} Complete... ");
            var response = _employeeService.DeleteEmployee(employeeId);
            return Ok(response);
        }

        [HttpPatch("/api/employee/recover/{employeeId}")]
        public ActionResult RecoverEmployee(int employeeId)
        {
            _logger.LogInformation($"Recovering Employee {employeeId} Complete... ");
            var response = _employeeService.RecoverEmployee(employeeId);
            return Ok(response);
        }
    }
}