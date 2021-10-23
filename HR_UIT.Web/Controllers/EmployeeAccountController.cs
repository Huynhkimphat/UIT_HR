using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
        /// Get All Employee Account ----- Admin
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

        /// <summary>
        /// Get Employee Account By Given Id ----- Admin And Staff
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/employee/account/{id}")]
        [Authorize(Policy = "Both")]
        public ActionResult GetEmployeeAccountById(int id)
        {
            _logger.LogInformation($"Getting account {id}");
            var employeeAccount = _employeeAccountService.GetEmployeeAccountById(id);
            return Ok(EmployeeAccountMapper.MapEmployeeAccount(employeeAccount));
        }
        
        /// <summary>
        /// Create New Account ----- Admin
        /// </summary>
        /// <param name="employeeAccount"></param>
        /// <returns></returns>
        [HttpPost("/api/employee/account/new")]
        [Authorize(Policy = "Admin")]
        public ActionResult CreateNewAccount([FromBody] EmployeeAccountModel employeeAccount)
        {
            _logger.LogInformation("Creating new accounts");
            var response =
                _employeeAccountService.CreateEmployeeAccount(
                    EmployeeAccountMapper.MapEmployeeAccount(employeeAccount));
            return Ok(response);
        }

        /// <summary>
        /// Change Account Password ----- Admin And Staff
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPatch("/api/employee/account/{id}/change")]
        [Authorize(Policy = "Both")]
        public ActionResult ChangeAccountPassword(int id, [FromBody] string password)
        {
            _logger.LogInformation($"Change Account Password For {id}");
            var response=_employeeAccountService.ChangeEmployeeAccountPassword(id, password);
            return Ok(response);
        }

        /// <summary>
        /// Delete Employee Account ----- Admin And Staff
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch("/api/employee/account/{id}/delete")]
        [Authorize(Policy = "Both")]
        public ActionResult DeleteEmployeeAccount(int id)
        {
            _logger.LogInformation($"Delete Employee Account {id}");
            var response=_employeeAccountService.DeleteEmployeeAccount(id);
            return Ok(response);
        }

        /// <summary>
        /// Recover Employee Account ----- Admin And Staff
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch("/api/employee/account/{id}/recover")]
        [Authorize(Policy = "Both")]
        public ActionResult RecoverEmployeeAccount(int id)
        {
            _logger.LogInformation($"Recover Employee Account {id}");
            var response=_employeeAccountService.RecoverEmployeeAccount(id);
            return Ok(response);
        }
        
        /// <summary>
        /// Login ----- Admin And Staff
        /// </summary>
        /// <returns></returns>
        [HttpPost("/api/login")]
        // [Authorize(Policy = "Both")]
        public ActionResult Login([FromBody] User user)
        {
            _logger.LogInformation("Logging In");

            var isLogin = _employeeAccountService.Login(user.Username, user.Password);
            var isAdmin = _employeeAccountService.IsAdmin(user.Username);
            if (!isLogin.IsSuccess) return Ok(isLogin);
            var Claims = new List<Claim>
            {
                isAdmin.Data
                    ? new Claim("type", "Admin")
                    : new Claim("type", "Staff"),
                new Claim("username", user.Username),
                new Claim("employeeId",isLogin.Data)
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
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set;}
    }
}