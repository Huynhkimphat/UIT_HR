using System;

namespace HR_UIT.Web.ViewModels
{
    public class EmployeeAttendanceModel
    {
        public int Id { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public bool IsProgressing { get; set; }

        public int Period { get; set; }
        
        public bool IsExisted {get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public bool IsArchived { get; set; }
    }
}