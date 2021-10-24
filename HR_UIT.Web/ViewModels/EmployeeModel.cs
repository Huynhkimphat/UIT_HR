using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using HR_UIT.Data.Models;
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

        public EmployeeAccountModel PrimaryAccount { get; set; }
        
        public List<EmployeeAttendanceModel> EmployeeAttendances { get; set; }
        //
        public EmployeeDayOffModel PrimaryDayOff { get; set; }
        //
        public List<EmployeeDayOffLetterModel> PrimaryDayOffLetters { get; set; }
        //
        public List<EmployeeSalaryModel> PrimarySalaries { get; set; }
        //
        public List<HolidayCreateModel> EmployeeHolidayCreates { get; set;}

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public bool IsArchived { get; set; }
    }
}