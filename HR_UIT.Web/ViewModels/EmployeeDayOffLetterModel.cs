using System;

namespace HR_UIT.Web.ViewModels
{
    public class EmployeeDayOffLetterModel
    {
        public int Id { get; set; }

        public DateTime FromDateTime { get; set; }

        public DateTime ToDateTime { get; set; }

        public string Reason { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
        
        public bool IsArchived { get; set; }

        public bool IsApproved { get; set; }

        public int DayOffCounting { get; set; }
    }
}