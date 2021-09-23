using System.Collections.Generic;

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
                Data.Models.EmployeeDayOffLetter employeeDayOffLetter
            );

        ServiceResponse<bool> UpdateEmployeeDayOffLetter(int id);
        
        ServiceResponse<bool> RecoverEmployeeDayOffLetter(int id);

        List<Data.Models.EmployeeDayOffLetter> GetAllEmployeeDayOffLetter();
        
        List<Data.Models.EmployeeDayOffLetter> GetAllEmployeeDayOffLetterByDay(int day);
        
        List<Data.Models.EmployeeDayOffLetter> GetAllEmployeeDayOffLetterByMonth(int month);
        
        List<Data.Models.EmployeeDayOffLetter> GetAllEmployeeDayOffLetterByYear(int year);

        ServiceResponse<bool> ApproveEmployeeDayOffLetter(int id);
    }
}