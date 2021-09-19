using System;

namespace HR_UIT.Data.Models
{
    public class EmployeeType
    {
        public int Id {get;set;}
        
        public string Name { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
        
        public bool IsArchived { get; set; }
    }
}