using System;

namespace HR_UIT.Web.ViewModels
{
    public class EmployeeSalaryModel
    {
        public int Id { get; set; }

        public SalaryDetailModel PrimarySalaryDetail { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public bool IsChecked { get; set; }
        
        public bool IsReceived { get; set; }

        public bool IsExisted {get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public bool IsArchived { get; set; }
    }
}