using System.Collections.Generic;
using System;

namespace HR_UIT.Services.EmployeeDayOff_Letter
{
    public interface IEmployeeDayOffLetterService
    {
        ServiceResponse<Data.Models.EmployeeDayOffLetter>
            CreateNewEmployeeDayOffLetter(
                Data.Models.EmployeeDayOffLetter employeeDayOffLetter
            );

        ServiceResponse<Data.Models.EmployeeDayOffLetter>
            UpdateEmployeeDayOffLetter(
                Data.Models.EmployeeDayOffLetter employeeDayOffLetter, int employeeDayOffLetterId
            );

        ServiceResponse<bool> DeleteEmployeeDayOffLetter(int id);
        
        ServiceResponse<bool> RecoverEmployeeDayOffLetter(int id);

        List<Data.Models.EmployeeDayOffLetter> GetAllEmployeeDayOffLetter();
        
        List<Data.Models.EmployeeDayOffLetter> GetAllEmployeeDayOffLetterByDay(DateTime day);
        
        List<Data.Models.EmployeeDayOffLetter> GetAllEmployeeDayOffLetterByMonth(DateTime month);
        
        List<Data.Models.EmployeeDayOffLetter> GetAllEmployeeDayOffLetterByWeek(DateTime week);

        ServiceResponse<bool> ApproveEmployeeDayOffLetter(int id);

        ServiceResponse<bool> AddDayOffLetterToEmployee(int dayOffLetterId, int employeeId);
        
        ServiceResponse<bool> RemoveDayOffLetterOutOfEmployee(int dayOffLetterId, int employeeId);
    }
}