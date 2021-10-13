using System.Linq;
using HR_UIT.Services.Employee;
using HR_UIT.Services.EmployeeType;
using HR_UIT.Web.Serialization;
using HR_UIT.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HR_UIT.Web.Controllers
{
    [ApiController]
    public class EmployeeTypeController : ControllerBase
    {
        private readonly IEmployeeTypeService _employeeTypeService;
        private readonly ILogger<EmployeeTypeController> _logger;

        public EmployeeTypeController(ILogger<EmployeeTypeController> logger, IEmployeeTypeService employeeTypeService)
        {
            _logger = logger;
            _employeeTypeService = employeeTypeService;
        }

        /// <summary>
        /// Get All Employee Types ----- Admin
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/employee/types")]
        [Authorize(Policy = "Admin")]
        public ActionResult GetAllEmployeeTypes()
        {
            _logger.LogInformation("Getting employeeTypes");
            var employeeTypes = _employeeTypeService.GetAllEmployeeTypes();
            var employeeTypeModels = employeeTypes
                .Select(EmployeeTypeMapper.MapEmployeeType)
                .OrderByDescending(employeeType => employeeType.Id)
                .ToList();
            return Ok(employeeTypeModels);
        }

        /// <summary>
        /// Get Employee Type By Given Id ----- Admin And Staff
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/employee/type")]
        [Authorize(Policy = "Both")]
        public ActionResult GetEmployeeTypeById(int id)
        {
            _logger.LogInformation($"Getting employeeType {id}");
            var employeeType = _employeeTypeService.GetTypeById(id);
            return Ok(employeeType);
        }

        /// <summary>
        /// Check Employee Has Role ----- Admin And Staff
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpGet("/api/employee/type/{employeeId}")]
        [Authorize(Policy = "Both")]  
        public ActionResult CheckEmployeeHasRole(int employeeId)
        {
            _logger.LogInformation($"Is Employee {employeeId}'s Role");
            var response = _employeeTypeService.IsEmployeeHasRole(employeeId);
            return Ok(response);
        }
        
        /// <summary>
        /// Create New Employee Type ----- Admin
        /// </summary>
        /// <param name="employeeType"></param>
        /// <returns></returns>
        [HttpPost("/api/employee/type")]
        [Authorize(Policy = "Admin")]
        public ActionResult CreateNewEmployeeType(EmployeeTypeModel employeeType)
        {
            _logger.LogInformation("Creating new employeeType");
            var response = _employeeTypeService.CreateEmployeeType(EmployeeTypeMapper.MapEmployeeType(employeeType));
            return Ok(response);
        }

        /// <summary>
        /// Update Employee Type Name By Id ----- Admin
        /// </summary>
        /// <param name="id"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        [HttpPatch("/api/employee/type/{id}")]
        [Authorize(Policy = "Admin")]
        public ActionResult UpdateEmployeeType(int id, [FromBody] string typeName)
        {
            _logger.LogInformation($"Update employeeType {id}");
            var response = _employeeTypeService.UpdateEmployeeTypeName(id, typeName);
            return Ok(response);
        }

        /// <summary>
        /// Delete Employee Type By Id ----- Admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch("/api/employee/type/{id}/delete")]
        [Authorize(Policy = "Admin")] 
        public ActionResult DeleteEmployeeType(int id)
        {
            _logger.LogInformation($"Delete employeeType {id}");
            var response = _employeeTypeService.DeleteEmployeeType(id);
            return Ok(response);
        }

        /// <summary>
        /// Recover Employee Type By Id ----- Admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch("/api/employee/type/{id}/recover")]
        [Authorize(Policy = "Admin")]  
        public ActionResult RecoverEmployeeType(int id)
        {
            _logger.LogInformation($"Recover employeeType {id}");
            var response = _employeeTypeService.RecoverEmployeeType(id);
            return Ok(response);
        }

        /// <summary>
        /// Update Role Of Employee With Given Id ----- Admin
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpPatch("/api/employee/type/{typeId}/add/{employeeId}")]
        [Authorize(Policy = "Admin")]  
        public ActionResult UpdateRoleOfEmployee(int typeId, int employeeId)
        {
            _logger.LogInformation($"Update Employee {employeeId} with Type {typeId}");
            var response = _employeeTypeService.UpdateEmployeeTypeEmployees(typeId, employeeId);
            return Ok(response);
        }

        /// <summary>
        /// Remove Role Of Employee With Given Id ----- Admin
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpPatch("/api/employee/type/remove/{employeeId}")]
        [Authorize(Policy = "Admin")]  
        public ActionResult RemoveRoleOfEmployee(int employeeId)
        {
            _logger.LogInformation($"Remove Employee {employeeId}'s Role");
            var response = _employeeTypeService.RemoveEmployeeTypeEmployees(employeeId);
            return Ok(response);
        }


    }
}