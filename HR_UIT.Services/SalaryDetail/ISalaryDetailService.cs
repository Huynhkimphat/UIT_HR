using System;
using System.Collections.Generic;
using HR_UIT.Data;
using HR_UIT.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using HR_UIT.Services.SalaryDetail;

namespace HR_UIT.Services.SalaryDetail
{
    public interface ISalaryDetailService
    {
        ServiceResponse<Data.Models.SalaryDetail>
            CreateSalaryDetail(
                Data.Models.SalaryDetail salaryDetail
            );

        ServiceResponse<Data.Models.SalaryDetail>
            CountFinalSalary(
                int id
            );

        Data.Models.SalaryDetail GetSalaryDetailById(int id);
        
        
        ServiceResponse<bool> DeleteSalaryDetail(int id);
        
    }
}