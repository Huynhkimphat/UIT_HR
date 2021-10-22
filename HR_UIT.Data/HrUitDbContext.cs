using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HR_UIT.Data.Models;

namespace HR_UIT.Data
{
    public class HrUitDbContext : IdentityDbContext
    {
        public HrUitDbContext() 
        {
        }

        public HrUitDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Employee> Employees { get; set; }
        
        public virtual DbSet<EmployeeAccount> EmployeeAccounts { get; set; }
        
        public virtual DbSet<EmployeeAddress> EmployeeAddresses { get; set; }
        
        public virtual DbSet<EmployeeAttendance> EmployeeAttendances { get; set; }
        
        public virtual DbSet<EmployeeDayOff> EmployeeDayOffs { get; set; }
        
        public virtual DbSet<EmployeeDayOffLetter> EmployeeDayOffLetters { get; set; }
        
        public virtual DbSet<EmployeeSalary> EmployeeSalaries { get; set; }
        
        public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }
        
        public virtual DbSet<Holiday> Holidays { get; set; }
        
        public virtual DbSet<HolidayCreate> HolidayCreates { get; set; }
        
        public virtual DbSet<SalaryDetail> SalaryDetails { get; set; }
        
    }
}
