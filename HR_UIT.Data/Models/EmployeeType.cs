using System;

namespace HR_UIT.Data.Models
{
    public class EmployeeType
    {
        public int Id {get;set;}
        
        public string Name { get; set; }
        
        public DateTime CreateOn { get; set; }

        public DateTime UpdateOn { get; set; }
        
        public bool IsAchieved { get; set; }
    }
}