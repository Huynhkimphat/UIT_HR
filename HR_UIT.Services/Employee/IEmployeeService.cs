using System.Collections.Generic;

namespace HR_UIT.Services.Employee
{
    public interface IEmployeeService
    {
        List<Data.Models.Employee> GetAllEmployees();
        
        List<Data.Models.Employee> GetAllEmployeesVisible();
        
        Data.Models.Employee GetEmployeeById(int id);

        
        ServiceResponse<Data.Models.Employee>
            CreateEmployee(
                Data.Models.Employee employee
            );

        ServiceResponse<Data.Models.Employee>
            UpdateEmployee(
                Data.Models.Employee employee
            );
        
        ServiceResponse<bool> DeleteEmployee(int id);
        
        
    }
}