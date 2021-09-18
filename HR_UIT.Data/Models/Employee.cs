using System;
using System.ComponentModel.DataAnnotations;

namespace HR_UIT.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public DateTime DateOfBirth { get; set; }
        
        [MaxLength(20)] public string PhoneNumber { get; set; }
        
        [MaxLength(20)] public string IdentityCard { get; set; }
        
        public EmployeeAddress PrimaryAddress { get;set;}
        
        public EmployeeType PrimaryRole { get; set; }

        public DateTime CreateOn { get; set; }

        public DateTime UpdateOn { get; set; }
        
        public bool IsAchieved { get; set; }
    }
}