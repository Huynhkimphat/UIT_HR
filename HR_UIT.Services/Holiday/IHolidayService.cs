using System;
using System.Collections.Generic;
namespace HR_UIT.Services.Holiday
{
    public interface IHolidayService
    {
        List<Data.Models.Holiday> GetAllHolidays();
        List<Data.Models.Holiday> GetHolidaysByMonth(DateTime month);
        Data.Models.Holiday GetHolidayById(int id);

        ServiceResponse<Data.Models.Holiday>
            CreateHoliday(
                Data.Models.Holiday holiday
            );

        ServiceResponse<Data.Models.Holiday>
            UpdateNameOfHoliday(
                Data.Models.Holiday holiday
            );

        ServiceResponse<bool> DeleteHoliday(int id);
        ServiceResponse<bool> RecoverHoliday(int id);

    }
}