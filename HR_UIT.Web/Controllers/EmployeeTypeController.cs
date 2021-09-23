using System.Linq;
using HR_UIT.Services.Employee;
using HR_UIT.Services.EmployeeType;
using HR_UIT.Web.Serialization;
using HR_UIT.Web.ViewModels;
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
        [HttpGet("/api/employee/types")]
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
        [HttpGet("/api/employee/type")]
        public ActionResult GetEmployeeTypeById(int id)
        {
            _logger.LogInformation($"Getting employeeType {id}");
            var employeeType = _employeeTypeService.GetTypeById(id);
            return Ok(employeeType);
        }
        [HttpPost("/api/employee/type")]
        public ActionResult CreateNewEmployeeType(EmployeeTypeModel employeeType)
        {
            _logger.LogInformation("Creating new employeeType");
            var response=_employeeTypeService.CreateEmployeeType(EmployeeTypeMapper.MapEmployeeType(employeeType));
            return Ok(response);
        }
        [HttpPatch("/api/employee/type/{id}")]
        public ActionResult UpdateEmployeeType(int id,[FromBody]string typeName)
        {
            _logger.LogInformation($"Update employeeType {id}");
            var response=_employeeTypeService.UpdateEmployeeTypeName(id,typeName);
            return Ok(response);
        }
        [HttpPatch("/api/employee/type/{id}/delete")]
        public ActionResult DeleteEmployeeType(int id)
        {
            _logger.LogInformation($"Delete employeeType {id}");
            var response = _employeeTypeService.DeleteEmployeeType(id);
            return Ok(response);
        }
        [HttpPatch("/api/employee/type/{id}/recover")]
        public ActionResult RecoverEmployeeType(int id)
        {
            _logger.LogInformation($"Recover employeeType {id}");
            var response = _employeeTypeService.RecoverEmployeeType(id);
            return Ok(response);
        }
    }
}