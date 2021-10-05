using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HR_UIT.Services.EmployeeAccount;
using HR_UIT.Web.Serialization;
using HR_UIT.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace HR_UIT.Web.Controllers
{
    [ApiController]
    public class EmployeeAccountController : ControllerBase
    {
        private readonly IEmployeeAccountService _employeeAccountService;
        private readonly ILogger<EmployeeAccountController> _logger;

        public EmployeeAccountController(ILogger<EmployeeAccountController> logger,
            IEmployeeAccountService employeeAccountService)
        {
            _logger = logger;
            _employeeAccountService = employeeAccountService;
        }

        [HttpGet("/api/employee/account/all")]
        public ActionResult GetAllEmployeeAccount()
        {
            _logger.LogInformation("Getting accounts");
            var employeeAccounts = _employeeAccountService.GetAllAccounts();
            var employeeAccountModels = employeeAccounts
                .Select(EmployeeAccountMapper.MapEmployeeAccount)
                .OrderByDescending(employeeAccount => employeeAccount.Id)
                .ToList();
            return Ok(employeeAccountModels);
        }

        [HttpPost("/api/employee/accout/new")]
        public ActionResult CreateNewAccount([FromBody] EmployeeAccountModel employeeAccount)
        {
            _logger.LogInformation("Creating new accounts");
            var response =
                _employeeAccountService.CreateEmployeeAccount(
                    EmployeeAccountMapper.MapEmployeeAccount(employeeAccount));
            return Ok(response);
        }

        [HttpGet("/api/login")]
        public ActionResult Login(string email, string password)
        {
            _logger.LogInformation("Logging In");
            if (true)
            {
                var Claims = new List<Claim>
                {
                    new Claim("type", "Admin")
                };
                
                var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SXkSqsKyNUyvGbnHs7ke2NCq8zQzNLW7mPmHbnZZ"));

                var Token = new JwtSecurityToken(
                    "https://hr-uit.com",
                    "https://hr-uit.com",
                    Claims,
                    expires: DateTime.Now.AddDays(30.0),
                    signingCredentials: new SigningCredentials(Key, SecurityAlgorithms.HmacSha256)
                );
                
                return new OkObjectResult(new JwtSecurityTokenHandler().WriteToken(Token));
            }
            else
            {
                return Ok(
                        _employeeAccountService
                        .Login(email, password)
                );
            }
            
        }
    }
}