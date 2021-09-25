using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace HR_UIT.Web.ViewModels
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [MaxLength(20)] public string PhoneNumber { get; set; }

        [MaxLength(20)] public string IdentityCard { get; set; }

        public EmployeeAddressModel PrimaryAddress { get; set; }

        // public EmployeeAccount PrimaryAccount { get; set; }
        //
        // public List<EmployeeAttendance> EmployeeAttendances { get; set; }
        //
        // public EmployeeDayOff PrimaryDayOff { get; set; }
        //
        // public List<EmployeeDayOff_Letter> PrimaryDayOff_Letters { get; set; }
        //
        // public List<EmployeeSalary> PrimarySalaries { get; set; }
        //
        public List<HolidayCreateModel> EmployeeHolidayCreates { get; set;}

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public bool IsArchived { get; set; }
    }
}
