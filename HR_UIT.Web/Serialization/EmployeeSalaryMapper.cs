using HR_UIT.Data.Models;
using HR_UIT.Web.ViewModels;

namespace HR_UIT.Web.Serialization
{
    public static class EmployeeSalaryMapper
    {
        /// <summary>
        ///     Maps an EmployeeSalary Data Model To an EmployeeSalary View Model
        /// </summary>
        /// <param name="salary"></param>
        /// <returns></returns>
        public static EmployeeSalaryModel
            MapEmployeeSalary(EmployeeSalary salary)
        {
            return new EmployeeSalaryModel
            {
                Id = salary.Id,
                Month = salary.Month,
                Year = salary.Year,
                UpdatedOn = salary.UpdatedOn,
                CreatedOn = salary.CreatedOn,
                IsArchived = salary.IsArchived,
                IsChecked = salary.IsChecked,
                IsReceived = salary.IsReceived,
                IsExisted = salary.IsExisted,
                PrimarySalaryDetail = (salary.PrimarySalaryDetail != null)
                    ? SalaryDetailMapper.MapSalaryDetail(salary.PrimarySalaryDetail)
                    : new SalaryDetailModel { },
            };
        }

        /// <summary>
        ///     Maps an EmployeeSalary View Model to an EmployeeSalary Data Model
        /// </summary>
        /// <param name="salary"></param>
        /// <returns></returns>
        public static EmployeeSalary
            MapEmployeeSalary(EmployeeSalaryModel salary)
        {
            return new EmployeeSalary
            {
                Id = salary.Id,
                Month = salary.Month,
                Year = salary.Year,
                UpdatedOn = salary.UpdatedOn,
                CreatedOn = salary.CreatedOn,
                IsArchived = salary.IsArchived,
                IsChecked = salary.IsChecked,
                IsReceived = salary.IsReceived,
                IsExisted = salary.IsExisted,
                PrimarySalaryDetail = SalaryDetailMapper
                    .MapSalaryDetail(
                        salary.PrimarySalaryDetail
                    ),
            };
        }
    }
}