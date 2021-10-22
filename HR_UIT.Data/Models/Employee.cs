using System;
using System.Collections.Generic;
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
        
        public EmployeeAccount PrimaryAccount { get; set; }

        public List<EmployeeAttendance> EmployeeAttendances { get; set; }

        public EmployeeDayOff PrimaryDayOff { get; set; }

        public List<EmployeeDayOffLetter> PrimaryDayOffLetters { get; set; }

        public List<EmployeeSalary> PrimarySalaries { get; set; }

        public List<HolidayCreate> EmployeeHolidayCreates { get; set;}

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
        
        public bool IsArchived { get; set; }
    }
}