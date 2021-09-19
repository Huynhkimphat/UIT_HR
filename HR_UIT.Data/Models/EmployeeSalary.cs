using System;
using System.ComponentModel.DataAnnotations;

namespace HR_UIT.Data.Models
{
    public class EmployeeSalary
    {
        public int Id { get; set; }

        public SalaryDetail PrimarySalaryDetail { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public bool IsChecked { get; set; }

        public bool IsReceived { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
        
        public bool IsArchived { get; set; }
    }
}