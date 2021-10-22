using System;
using System.ComponentModel.DataAnnotations;

namespace HR_UIT.Data.Models
{
    public class EmployeeDayOffLetter
    {
        public int Id { get; set; }

        public DateTime FromDateTime { get; set; }

        public DateTime ToDateTime { get; set; }

        public string Reason { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
        
        public bool IsExisted { get; set; }
        
        public bool IsArchived { get; set; }

        public bool IsApproved { get; set; }

        public int DayOffCounting { get; set; }
    }
}