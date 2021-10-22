using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HR_UIT.Web.ViewModels
{
    public class HolidayModel
    {
        public int Id { get; set; }
        public string NameOfHoliday { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdateOn { get; set; }
        public List<HolidayCreateModel> PrimaryHolidayCreates { get; set; }
        
 
        public bool IsArchived { get; set; }
    }
}