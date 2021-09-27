using System.Linq;
using HR_UIT.Services.EmployeeAccount;
using HR_UIT.Web.Serialization;
using HR_UIT.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
            return Ok(
                _employeeAccountService
                    .Login(email, password)
            );
        }
    }
}