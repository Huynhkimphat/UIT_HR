using System;

namespace HR_UIT.Web.ViewModels
{
    public class EmployeeDayOffModel
    {
        public int Id { get; set; }

        public int DayOffAmount { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
        
        public bool IsArchived { get; set; }
    }
}