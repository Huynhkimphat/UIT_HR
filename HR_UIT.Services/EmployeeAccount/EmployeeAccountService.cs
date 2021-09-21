using System;
using System.Collections.Generic;
using System.Linq;
using HR_UIT.Data;
using Microsoft.EntityFrameworkCore;

namespace HR_UIT.Services.EmployeeAccount
{
    public class EmployeeAccountService : IEmployeeAccountService
    {
        private readonly HrUitDbContext _db;

        public EmployeeAccountService(HrUitDbContext dbContext)
        {
            _db = dbContext;
        }

        /// <summary>
        /// Get a List of Accounts from database
        /// </summary>
        /// <returns></returns>
        public List<Data.Models.EmployeeAccount> GetAllAccounts()
        {
            return _db
                .EmployeeAccounts
                .OrderBy(employeeAccount => employeeAccount.Id)
                .ToList();
        }
        
        /// <summary>
        /// Get an Account from database with the given Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Data.Models.EmployeeAccount GetEmployeeAccountById(int id)
        {
            return _db.EmployeeAccounts.Find(id);
        }

        /// <summary>
        /// Create new EmployeeAccount
        /// </summary>
        /// <param name="employeeAccount"></param>
        /// <returns></returns>
        public ServiceResponse<Data.Models.EmployeeAccount> CreateEmployeeAccount(Data.Models.EmployeeAccount employeeAccount)
        {
            var now = DateTime.UtcNow;
            try
            {
                _db.EmployeeAccounts.Add(employeeAccount);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.EmployeeAccount>
                {
                    Data = employeeAccount,
                    Time = now,
                    Message = "Saved new employeeAccount",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.EmployeeAccount>
                {
                    Data = null,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }
        
        /// <summary>
        /// Change Account Password with given AccountId 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public ServiceResponse<Data.Models.EmployeeAccount> ChangeEmployeeAccountPassword(int id,string newPassword)
        {
            var now = DateTime.UtcNow;
            var employeeAccount = _db.EmployeeAccounts.Find(id);
            if (employeeAccount == null)
            {
                return new ServiceResponse<Data.Models.EmployeeAccount>
                {
                    Data = null,
                    Time = now,
                    Message = $"Update Password EmployeeAccount {id} failed ",
                    IsSuccess = false
                };
            }
            try
            {
                employeeAccount.Password = newPassword;
                _db.Update(employeeAccount);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.EmployeeAccount>
                {
                    Data = employeeAccount,
                    Time = now,
                    Message = $"Updated Password EmployeeAccount {id}",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.EmployeeAccount>
                {
                    Data = null,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }
        
        /// <summary>
        /// Delete an Account with the given AccountId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponse<bool> DeleteEmployeeAccount(int id)
        {
            var now = DateTime.UtcNow;
            var employeeAccount = _db.EmployeeAccounts.Find(id);
            if (employeeAccount == null)
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "EmployeeAccount to archive not found",
                    IsSuccess = false
                };
            try
            {
                employeeAccount.UpdatedOn = now;
                employeeAccount.IsArchived = true;
                _db.EmployeeAccounts.Update(employeeAccount);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "EmployeeAccount Archived",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }
    }
}