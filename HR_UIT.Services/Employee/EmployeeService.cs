using System.Collections.Generic;
using HR_UIT.Data;
using HR_UIT.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace HR_UIT.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HrUitDbContext _db;
        
        public EmployeeService(HrUitDbContext dbContext)
        {
            _db = dbContext;
        }
        
        /// <summary>
        /// Return a list of Employees from database 
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllEmployees()
        {
            return _db
                .Employees
                .Include(employee => employee.PrimaryAddress)
                // .Include(employee => employee.PrimaryAccount)
                // .Include(employee => employee.PrimaryDayOff)
                .OrderBy(employee => employee.Id)
                .ToList();
        }

        public ServiceResponse<Employee> CreateEmployee(Employee customer)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResponse<bool> DeleteEmployee(int id)
        {
            throw new System.NotImplementedException();
        }

        public Employee GetEmployeeById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}