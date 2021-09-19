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

        public EmployeeAccount PrimaryAccount { get; set; }

        public EmployeeAttendance PrimaryAttendance { get; set; }

        public EmployeeDayOff_Letter PrimaryDayOff_Letter { get; set; }

        public EmployeeDayoff PrimaryDayOff { get; set; }

        public EmployeeSalary PrimarySalary { get; set; }

        public Holiday_Create EmployeeHoliday_Create { get; set;}

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
        
        public bool IsArchived { get; set; }
    }
}