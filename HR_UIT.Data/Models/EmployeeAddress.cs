using System;
using System.ComponentModel.DataAnnotations;

namespace HR_UIT.Data.Models
{
    public class EmployeeAddress
    {
        public int Id { get; set; }

        [MaxLength(100)] public string AddressLine { get; set; }

        [MaxLength(100)] public string Ward { get; set; }
        
        [MaxLength(100)] public string District { get; set; }

        [MaxLength(100)] public string City { get; set; }

        [MaxLength(100)] public string Country { get; set; }
        
        public DateTime CreateOn { get; set; }

        public DateTime UpdateOn { get; set; }
    }
}