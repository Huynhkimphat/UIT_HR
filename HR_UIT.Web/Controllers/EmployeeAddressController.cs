using System.Linq;
using HR_UIT.Services.EmployeeAddress;
using HR_UIT.Web.Serialization;
using HR_UIT.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HR_UIT.Web.Controllers
{
    [ApiController]
    public class EmployeeAddressController : ControllerBase
    {
        private readonly IEmployeeAddressService _employeeAddressService;
        private readonly ILogger<EmployeeAddressController> _logger;

        public EmployeeAddressController(ILogger<EmployeeAddressController> logger,
            IEmployeeAddressService employeeAddressService)
        {
            _logger = logger;
            _employeeAddressService = employeeAddressService;
        }

        /// <summary>
        /// Get All Employee Addresses ----- Admin 
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/employee/addresses")]
        [Authorize(Policy = "Admin")]
        public ActionResult GetAllEmployeeAddresses()
        {
            _logger.LogInformation("Getting all employeesAddresses");
            var employeesAddresses = _employeeAddressService.GetEmployeeAddresses();
            var employeeModels = employeesAddresses
                .Select(employeeAddress => new EmployeeAddressModel
                {
                    Id = employeeAddress.Id,
                    AddressLine = employeeAddress.AddressLine,
                    Ward = employeeAddress.Ward,
                    District = employeeAddress.District,
                    City = employeeAddress.City,
                    Country = employeeAddress.Country,
                    CreatedOn = employeeAddress.CreatedOn,
                    UpdatedOn = employeeAddress.UpdatedOn,
                })
                .OrderByDescending(employeeAddress => employeeAddress.Id)
                .ToList();
            return Ok(employeeModels);
        }

        /// <summary>
        /// Get Employee Address By Given Id ----- Admin And Staff
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/employee/address")]
        [Authorize(Policy = "Both")]
        public ActionResult GetAddressByEmployeeId(int id)
        {
            _logger.LogInformation($"Getting employeeAddress {id}");
            var response = _employeeAddressService.GetEmployeeAddressById(id);
            return Ok(response);
        }

        /// <summary>
        /// Create New Address ----- Admin And Staff
        /// </summary>
        /// <param name="employeeAddress"></param>
        /// <returns></returns>
        [HttpPost("/api/employee/address/new")]
        [Authorize(Policy = "Both")]
        public ActionResult CreateAddress([FromBody] EmployeeAddressModel employeeAddress)
        {
            _logger.LogInformation("Creating new employeeAddress");
            var response =
                _employeeAddressService.CreateEmployeeAddress(
                    EmployeeAddressMapper.MapEmployeeAddress(employeeAddress));
            return Ok(response);
        }

        /// <summary>
        /// Update Employee Address ----- Admin And Staff
        /// </summary>
        /// <param name="employeeAddress"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("/api/employee/address/update")]
        public ActionResult UpdateEmployeeAddress([FromBody] EmployeeAddressModel employeeAddress, int id)
        {
            _logger.LogInformation($"Updating new employeeAddress {id}");
            var response =
                _employeeAddressService.UpdateEmployeeAddress(EmployeeAddressMapper.MapEmployeeAddress(employeeAddress),
                    id);
            return Ok(response);
        }
    }
}