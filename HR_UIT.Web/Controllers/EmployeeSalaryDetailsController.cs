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
        /// Admin authorize
        /// Create new employee salary detail
        /// </summary>
        /// <param name="salaryDetail"></param>
        /// <returns></returns>
        [HttpPost("/api/salaryDetail")]
        [Authorize(Policy = "Admin")]
        public ActionResult CreateNewSalaryDetail([FromBody] SalaryDetailModel salaryDetail)
        {
            _logger.LogInformation("Creating New Salary Detail");
            var response = _salaryDetailService.CreateSalaryDetail(SalaryDetailMapper.MapSalaryDetail(salaryDetail));
            return Ok(response);
        }

        /// <summary>
        /// Admin authorize
        /// Counting for final salary
        /// </summary>
        /// <param name="salaryDetailId"></param>
        /// <returns></returns>
        [HttpPatch("api/salaryDetail/{salaryDetailId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult CountFinalSalary(int salaryDetailId)
        {
            _logger.LogInformation($"Counting for final Salary Id: {salaryDetailId}");
            var response = _salaryDetailService.CountFinalSalary(salaryDetailId);
            return Ok(response);
        }

        /// <summary>
        /// Admin, Staff Authorize
        /// Getting Salary Detail By Id
        /// </summary>
        /// <param name="salaryDetailId"></param>
        /// <returns></returns>
        [HttpGet("api/SalaryDetail/{salaryDetailId}")]
        [Authorize(Policy = "Both")]
        public ActionResult GetSalaryDetailById(int salaryDetailId)
        {
            _logger.LogInformation($"Getting Salary Detail Id: {salaryDetailId}");
            var response = _salaryDetailService.GetSalaryDetailById(salaryDetailId);
            return Ok(response);

        }

        /// <summary>
        /// Admin authorize
        /// Delete Salary Detail
        /// </summary>
        /// <param name="salaryDetailId"></param>
        /// <returns></returns>
        [HttpPatch("api/SalaryDetail/delete/{salaryDetailId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult DeleteSalaryDetail(int salaryDetailId)
        {
            _logger.LogInformation($"Deleting Salary Detail Id: {salaryDetailId}");
            var response = _salaryDetailService.DeleteSalaryDetail(salaryDetailId);
            return Ok(response);
        }
    }
}