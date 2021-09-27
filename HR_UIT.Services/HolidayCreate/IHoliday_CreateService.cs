using System;
using System.Collections.Generic;

namespace HR_UIT.Services.HolidayCreate
{
    public interface IHolidayCreateService
    {
        List<Data.Models.Holiday_Create> GetAllHolidaysOff();
        List<Data.Models.Holiday_Create> GetAllHolidaysOffByMonth(DateTime month);

        ServiceResponse<Data.Models.Holiday_Create>
            CreateHolidayOff(
                Data.Models.Holiday_Create holidayOff
                );

        ServiceResponse<Data.Models.Holiday_Create>
            UpdateHolidayOff(
                Data.Models.Holiday_Create holidayOff, int holidayOffId
            );

        ServiceResponse<bool> DeleteHolidayOff(int id);
        ServiceResponse<bool> RecoverHolidayOff(int id);
    }
}