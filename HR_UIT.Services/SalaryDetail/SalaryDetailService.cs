using System;
using System.Linq;
using HR_UIT.Data;

namespace HR_UIT.Services.SalaryDetail
{
    public class SalaryDetailService : ISalaryDetailService
    {
        private readonly HrUitDbContext _db;

        public SalaryDetailService(HrUitDbContext dbContext)
        {
            _db = dbContext;
        }

        /// <summary>
        /// Count Final Salary
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponse<Data.Models.SalaryDetail> CountFinalSalary(int id)
        {
            var now = DateTime.UtcNow;
            var salaryDetail = _db.SalaryDetails.Find(id);
            if (salaryDetail == null)
                return new ServiceResponse<Data.Models.SalaryDetail>
                {
                    Data = null,
                    Time = now,
                    Message = "Salary Detail not found",
                    IsSuccess = false
                };
            try
            {
                salaryDetail.FinalSalary = salaryDetail.EstimatedSalary + salaryDetail.Bonus - salaryDetail.Taxes -
                                           salaryDetail.Minus;
                salaryDetail.UpdatedOn = now;
                _db.SalaryDetails.Update(salaryDetail);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.SalaryDetail>
                {
                    Data = salaryDetail,
                    Time = now,
                    Message = $"Salary Detail {salaryDetail.Id}: Updated final salary",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.SalaryDetail>
                {
                    Data = null,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

        /// <summary>
        /// Create new Salary detail
        /// </summary>
        /// <param name="salaryDetail"></param>
        /// <returns></returns>
        public ServiceResponse<Data.Models.SalaryDetail> CreateSalaryDetail(Data.Models.SalaryDetail salaryDetail)
        {
            var now = DateTime.UtcNow;
            try
            {
                _db.SalaryDetails.Add(salaryDetail);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.SalaryDetail>
                {
                    Data = salaryDetail,
                    Time = now,
                    Message = "Saved new Salary Detail",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.SalaryDetail>
                {
                    Data = null,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

        /// <summary>
        /// Get salary detail by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Data.Models.SalaryDetail GetSalaryDetailById(int id)
        {
            return _db.SalaryDetails.FirstOrDefault(e => e.Id == id);
        }
        
        /// <summary>
        /// Delete salary detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponse<bool> DeleteSalaryDetail(int id)
        {
            var now = DateTime.UtcNow;
            var salaryDetail = _db.SalaryDetails.Find(id);
            if (salaryDetail == null)
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "Salary Detail To archive not found",
                    IsSuccess = false
                };
            try
            {
                salaryDetail.UpdatedOn = now;
                salaryDetail.IsArchived = true;
                _db.SalaryDetails.Update(salaryDetail);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "Employee Archived",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }
    }
}