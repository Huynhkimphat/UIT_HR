using System.Collections.Generic;
namespace HR_UIT.Services.Holiday
{
    public interface IHolidayService
    {
        List<Data.Models.Holiday> GetAllHolidays();
        List<Data.Models.Holiday> GetAllHolidaysVisible();
        Data.Models.Holiday GetHolidayById(int id);

        ServiceResponse<Data.Models.Holiday>
            CreateHoliday(
                Data.Models.Holiday holiday
            );

        ServiceResponse<Data.Models.Holiday>
            UpdateHoliday(
                Data.Models.Holiday holiday
            );

        
    }
}