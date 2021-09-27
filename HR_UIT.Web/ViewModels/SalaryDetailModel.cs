using System;

namespace HR_UIT.Web.ViewModels
{
    public class SalaryDetailModel
    {
        public int Id { get; set; }

        public int EstimatedSalary { get; set; }

        public int EstimatedDayWorking { get; set; }

        public int RealityDayWorking { get; set; }

        public int Bonus { get; set; }

        public int Taxes { get; set; }

        public int Minus { get; set; }

        public int FinalSalary { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public bool IsArchived { get; set; }
    }
}