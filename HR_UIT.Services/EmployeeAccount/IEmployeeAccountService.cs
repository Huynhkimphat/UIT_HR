using System.Collections.Generic;

namespace HR_UIT.Services.EmployeeAccount
{
    public interface IEmployeeAccount
    {
        // List<Data.Models.EmployeeAccount> GetAllAccount();
        //
        // List<Data.Models.EmployeeAccount> GetAllEmployeesVisible();
        
        Data.Models.EmployeeAccount GetEmployeeAccountById(int id);

        
        ServiceResponse<Data.Models.EmployeeAccount>
            CreateEmployeeAccount(
                Data.Models.Employee employee
            );

        ServiceResponse<Data.Models.Employee>
            ChangeEmployeeAccountPassword(
                int id
            );
        
        ServiceResponse<bool> DeleteEmployeeAccount(int id);
    }
}