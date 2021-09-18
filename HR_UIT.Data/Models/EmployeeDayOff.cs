using System;
using System.ComponentModel.DataAnnotations;

namespace HR_UIT.Data.Models
{
    public class EmployeeDayOff
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int DayOffAmmount { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
        
        public bool IsAchieved { get; set; }
    }
}