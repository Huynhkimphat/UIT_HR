﻿using System.Linq;
using HR_UIT.Services.EmployeeAddress;
using HR_UIT.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HR_UIT.Web.Controllers
{
    [ApiController]
    public class EmployeeAddressController :ControllerBase
    {
        private readonly IEmployeeAddressService _employeeAddressService;
        private readonly ILogger<EmployeeAddressController> _logger;
        
        public EmployeeAddressController(ILogger<EmployeeAddressController> logger, IEmployeeAddressService employeeAddressService)
        {
            _logger = logger;
            _employeeAddressService = employeeAddressService;
        }
        
        [HttpGet("/api/employee/addresses")]
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
    }
}