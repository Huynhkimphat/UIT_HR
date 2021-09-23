using System.Collections.Generic;

namespace HR_UIT.Services.EmployeeType
{
    public interface IEmployeeTypeService
    {
        List<Data.Models.EmployeeType> GetAllEmployeeTypes();

        Data.Models.EmployeeType GetTypeById(int id);
        
        ServiceResponse<Data.Models.EmployeeType> 
            CreateEmployeeType(
                Data.Models.EmployeeType employeeType
                );

        ServiceResponse<bool> DeleteEmployeeType(int id);
        
        ServiceResponse<bool> RecoverEmployeeType(int id);

        ServiceResponse<Data.Models.EmployeeType>
            UpdateEmployeeTypeName(
                int id, string typeName
            );

        ServiceResponse<Data.Models.EmployeeType>
            UpdateEmployeeTypeEmployees(
                int typeId, int employeeId
            );
    }
}