using System;
using System.Collections.Generic;

namespace HR_UIT.Data.Models
{
    public class Holiday
    {
        public int Id { get; set; }

        public string NameOfHoliday { get; set; }

        public DateTime DateOfHoliday { get; set; }
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public bool IsArchived { get; set; }

        public HolidayCreate PrimaryHolidayCreate { get; set; }
    }
}