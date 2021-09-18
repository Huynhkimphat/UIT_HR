using System;
using System.ComponentModel.DataAnnotations;

namespace HR_UIT.Data.Models
{
    public class EmployeeAccount
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
        
        public bool IsAchieved { get; set; }
    }
}