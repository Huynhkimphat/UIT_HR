using System;

namespace HR_UIT.Data.Models
{
    public class Holiday
    {
        public int Id {get;set;}
        
        public string NameOfHoliday { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
        
        public bool IsArchived { get; set; }

        public Holiday_Create PrimaryHoliday_Create { get; set; }
    }
}