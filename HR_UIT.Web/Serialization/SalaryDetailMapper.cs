using HR_UIT.Data.Models;
using HR_UIT.Web.ViewModels;

namespace HR_UIT.Web.Serialization
{
    public static class SalaryDetailMapper
    {
        /// <summary>
        ///     Maps an SalaryDetail Data Model To an SalaryDetail View Model
        /// </summary>
        /// <param name="salDetail"></param>
        /// <returns></returns>
        public static SalaryDetailModel
            MapSalaryDetail(SalaryDetail salDetail)
        {
            return new SalaryDetailModel
            {
                Id = salDetail.Id,
                EstimatedSalary = salDetail.EstimatedSalary,
                EstimatedDayWorking = salDetail.EstimatedDayWorking,
                RealityDayWorking = salDetail.RealityDayWorking,
                Bonus = salDetail.Bonus,
                Taxes = salDetail.Taxes,
                Minus = salDetail.Minus,
                FinalSalary = salDetail.FinalSalary,
                CreatedOn = salDetail.CreatedOn,
                UpdatedOn = salDetail.UpdatedOn,
                IsArchived = salDetail.IsArchived,
            };
        }

        /// <summary>
        ///     Maps an SalaryDetail View Model To an Salary Detail Data Model
        /// </summary>
        /// <param name="salDetail"></param>
        /// <returns></returns>
        public static SalaryDetail
            MapSalaryDetail(SalaryDetailModel salDetail)
        {
            return new SalaryDetail
            {
                EstimatedSalary = salDetail.EstimatedSalary,
                EstimatedDayWorking = salDetail.EstimatedDayWorking,
                RealityDayWorking = salDetail.RealityDayWorking,
                Bonus = salDetail.Bonus,
                Taxes = salDetail.Taxes,
                Minus = salDetail.Minus,
                FinalSalary = salDetail.FinalSalary,
                CreatedOn = salDetail.CreatedOn,
                UpdatedOn = salDetail.UpdatedOn,
                IsArchived = salDetail.IsArchived,
            };
        }
    }
}