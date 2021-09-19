using System.Collections.Generic;

namespace HR_UIT.Services
{
    public interface IEmployeeService
    {
        List<Data.Models.Employee> GetAllEmployees();
        
        List<Data.Models.Employee> GetAllEmployeesVisible();
        
        ServiceResponse<Data.Models.Employee>
            CreateEmployee(
                Data.Models.Employee employee
            );
        
        ServiceResponse<bool> DeleteEmployee(int id);
        
        Data.Models.Employee GetEmployeeById(int id);
    }
}