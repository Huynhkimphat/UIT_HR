using System.Collections.Generic;

namespace HR_UIT.Services.EmployeeDayOffService
{
    public interface IEmployeeDayOffServices
    {
        ServiceResponse<Data.Models.EmployeeDayOff>
            CreateNewEmployeeDayOff(
                Data.Models.EmployeeDayOff employeeDayOff
            );

        ServiceResponse<Data.Models.EmployeeDayOff>
            UpdateEmployeeDayOff(
                Data.Models.EmployeeDayOff employeeDayOff
            );

        List<Data.Models.EmployeeDayOff> GetAllEmployeeDayOff();

        Data.Models.EmployeeDayOff GetEmployeeDayOffById(int id);

        ServiceResponse<bool> DeleteEmployeeDayOff(int id);

        ServiceResponse<Data.Models.EmployeeDayOff> RecoverEmployeeDayOff(int id);

    }
}