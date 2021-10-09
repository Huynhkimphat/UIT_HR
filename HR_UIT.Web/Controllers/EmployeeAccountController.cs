using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HR_UIT.Services;
using HR_UIT.Services.EmployeeAccount;
using HR_UIT.Web.Serialization;
using HR_UIT.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

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

        /// <summary>
        /// Admin
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/employee/account/all")]
        [Authorize(Policy = "Admin")]
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
        [Authorize(Policy = "Admin")]
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

            var isLogin = _employeeAccountService.Login(email, password);
            
            if (isLogin.IsSuccess == true)
            {
                bool isAdmin = false;
                var Claims = new List<Claim>();
                if (isAdmin)
                {
                    Claims.Add(new Claim("type", "Admin"));
                }
                else
                {
                    Claims.Add(new Claim("type", "Staff"));
                }
                
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
                return Ok(isLogin);
            }
            
        }
    }
}