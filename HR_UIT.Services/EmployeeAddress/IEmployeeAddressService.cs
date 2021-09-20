using System.Collections.Generic;

namespace HR_UIT.Services.EmployeeAddress
{
    public interface IEmployeeAddressService
    {
        List<Data.Models.EmployeeAddress> GetEmployeeAddress(int id);
        
        ServiceResponse<Data.Models.EmployeeAddress>
            CreateEmployeeAddress(
                Data.Models.EmployeeAddress employeeAddress
            );
        
        
        Data.Models.Employee GetEmployeeById(int id);
    }
}