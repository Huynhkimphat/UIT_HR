using System;
using System.Collections.Generic;

namespace HR_UIT.Services.HolidayCreate
{
    public interface IHolidayCreateService
    {
        List<Data.Models.HolidayCreate> GetAllHolidaysOff();
        
        List<Data.Models.HolidayCreate> GetAllHolidaysOffByMonth(DateTime month);

        ServiceResponse<Data.Models.HolidayCreate>
            CreateHolidayOff(
                Data.Models.HolidayCreate holidayOff
                );

        ServiceResponse<Data.Models.HolidayCreate>
            UpdateHolidayOff(
                Data.Models.HolidayCreate holidayOff, int holidayOffId
            );

        ServiceResponse<bool> DeleteHolidayOff(int id);
        ServiceResponse<bool> RecoverHolidayOff(int id);

        ServiceResponse<bool> AddHolidayCreateToEmployee(int holidayCreateId, int employeeId);

        ServiceResponse<bool> RemoveHolidayCreateOutOfEmployee(int holidayCreateId, int employeeId);

        ServiceResponse<bool> AddHolidayCreateToHoliday(int holidayCreateId, int holidayId);

        ServiceResponse<bool> RemoveHolidayCreateOutOfHoliday(int holidayCreateId, int holidayId);
    }
}