using System.Collections.Generic;

namespace HR_UIT.Services.EmployeeAddress
{
    public interface IEmployeeAddressService
    {
        List<Data.Models.EmployeeAddress> GetEmployeeAddresses();
        
        ServiceResponse<Data.Models.EmployeeAddress>
            CreateEmployeeAddress(
                Data.Models.EmployeeAddress employeeAddress
            );
        
        Data.Models.EmployeeAddress GetEmployeeAddressById(int id);
        
        ServiceResponse<Data.Models.EmployeeAddress> UpdateEmployeeAddress(Data.Models.EmployeeAddress employeeAddress,int id);
    }
}