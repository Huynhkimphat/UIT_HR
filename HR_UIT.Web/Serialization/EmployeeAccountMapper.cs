using System;
using HR_UIT.Data.Models;
using HR_UIT.Web.ViewModels;

namespace HR_UIT.Web.Serialization
{
    public static class EmployeeAccountMapper
    {
        /// <summary>
        ///     Maps an EmployeeAccount Data Model to an EmployeeAccount View Model
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static EmployeeAccountModel
            MapEmployeeAccount(EmployeeAccount account)
        {
            return new EmployeeAccountModel
            {
                Id = account.Id,
                Email = account.Email,
                Password = account.Password,
                CreatedOn = account.CreatedOn,
                UpdatedOn = account.UpdatedOn,
                IsArchived = account.IsArchived,
            };
        }


        /// <summary>
        ///     Maps an EmployeeAccount View Model to an EmployeeAccount Data Model
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static EmployeeAccount
            MapEmployeeAccount(EmployeeAccountModel account)
        {
            var now = DateTime.UtcNow;
            return new EmployeeAccount
            {
                Email = account.Email,
                Password = account.Password,
                CreatedOn = now,
                UpdatedOn = now,
                IsArchived = account.IsArchived,
            };
        }
    }
}