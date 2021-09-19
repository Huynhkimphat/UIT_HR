using System;

namespace HR_UIT.Data.Models
{
    public class Holiday_Create
    {
        public int Id {get;set;}

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
        
        public bool IsArchived { get; set; }
    }
}