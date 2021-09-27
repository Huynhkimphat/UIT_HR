using System.Collections.Generic;

namespace HR_UIT.Services.EmployeeDayOffService
{
    public interface IEmployeeDayOffService
    {
        ServiceResponse<Data.Models.EmployeeDayOff>
            CreateNewEmployeeDayOff(
                Data.Models.EmployeeDayOff employeeDayOff
            );

        ServiceResponse<Data.Models.EmployeeDayOff>
            UpdateEmployeeDayOff(
                Data.Models.EmployeeDayOff employeeDayOff, int employeeDayOffId
            );

        List<Data.Models.EmployeeDayOff> GetAllEmployeeDayOff();

        Data.Models.EmployeeDayOff GetEmployeeDayOffById(int id);

        ServiceResponse<bool> DeleteEmployeeDayOff(int id);

        ServiceResponse<bool> RecoverEmployeeDayOff(int id);

    }
}