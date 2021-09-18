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
        
    }
}
