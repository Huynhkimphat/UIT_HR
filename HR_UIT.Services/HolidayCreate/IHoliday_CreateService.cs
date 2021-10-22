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
    }
}