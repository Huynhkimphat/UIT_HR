using Microsoft.AspNetCore.Mvc;
using System.Linq;
using HR_UIT.Data.Models;
using HR_UIT.Services.SalaryDetail;
using HR_UIT.Web.Serialization;
using HR_UIT.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
namespace HR_UIT.Web.Controllers
{
    [ApiController]
    public class EmployeeSalaryDetailsController : ControllerBase
    {
        private readonly ISalaryDetailService _salaryDetailService;
        private readonly ILogger<EmployeeSalaryDetailsController> _logger;

        public EmployeeSalaryDetailsController(ILogger<EmployeeSalaryDetailsController> logger,
            ISalaryDetailService salaryDetailService)
        {
            _logger = logger;
            _salaryDetailService = salaryDetailService;
        }

        /// <summary>
        /// Create New Employee Salary Detail ----- Admin
        /// </summary>
        /// <param name="salaryDetail"></param>
        /// <returns></returns>
        [HttpPost("/api/salary-detail")]
        [Authorize(Policy = "Admin")]
        public ActionResult CreateNewSalaryDetail([FromBody] SalaryDetailModel salaryDetail)
        {
            _logger.LogInformation("Creating New Salary Detail");
            var response = _salaryDetailService.CreateSalaryDetail(SalaryDetailMapper.MapSalaryDetail(salaryDetail));
            return Ok(response);
        }

        /// <summary>
        /// Counting For Final Salary ----- Admin
        /// </summary>
        /// <param name="salaryDetailId"></param>
        /// <returns></returns>
        [HttpPatch("/api/salary-detail/{salaryDetailId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult CountFinalSalary(int salaryDetailId)
        {
            _logger.LogInformation($"Counting for final Salary Id: {salaryDetailId}");
            var response = _salaryDetailService.CountFinalSalary(salaryDetailId);
            return Ok(response);
        }

        /// <summary>
        /// Getting Salary Detail By Id ----- Both
        /// </summary>
        /// <param name="salaryDetailId"></param>
        /// <returns></returns>
        [HttpGet("/api/salary-detail/{salaryDetailId}")]
        [Authorize(Policy = "Both")]
        public ActionResult GetSalaryDetailById(int salaryDetailId)
        {
            _logger.LogInformation($"Getting Salary Detail Id: {salaryDetailId}");
            var response = _salaryDetailService.GetSalaryDetailById(salaryDetailId);
            return Ok(SalaryDetailMapper.MapSalaryDetail(response));

        }

        /// <summary>
        /// Delete Salary Detail ----- Admin
        /// </summary>
        /// <param name="salaryDetailId"></param>
        /// <returns></returns>
        [HttpPatch("/api/salary-detail/delete/{salaryDetailId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult DeleteSalaryDetail(int salaryDetailId)
        {
            _logger.LogInformation($"Deleting Salary Detail Id: {salaryDetailId}");
            var response = _salaryDetailService.DeleteSalaryDetail(salaryDetailId);
            return Ok(response);
        }
    }
}