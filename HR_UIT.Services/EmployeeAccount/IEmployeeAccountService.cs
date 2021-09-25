using System.Collections.Generic;

namespace HR_UIT.Services.EmployeeAccount
{
    public interface IEmployeeAccountService
    {
        List<Data.Models.EmployeeAccount> GetAllAccounts();
        
        // List<Data.Models.EmployeeAccount> GetAllEmployeesVisible();
        
        Data.Models.EmployeeAccount GetEmployeeAccountById(int id);

        
        ServiceResponse<Data.Models.EmployeeAccount>
            CreateEmployeeAccount(
                Data.Models.EmployeeAccount employeeAccount
            );

        ServiceResponse<Data.Models.EmployeeAccount>
            ChangeEmployeeAccountPassword(
                int id,string newPassword
            );
        
        ServiceResponse<bool> DeleteEmployeeAccount(int id);
        
        ServiceResponse<bool> RecoverEmployeeAccount(int id);

        ServiceResponse<Data.Models.EmployeeAccount> Login(string username, string password);
    }
}