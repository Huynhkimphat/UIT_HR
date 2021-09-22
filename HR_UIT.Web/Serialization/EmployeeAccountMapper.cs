using HR_UIT.Data.Models;
using HR_UIT.Web.ViewModels;

namespace HR_UIT.Web.Serialization
{
    public class EmployeeAccountMapper
    {
        /// <summary>
        ///     Maps a EmployeeAccount Data Model to EmployeeAccount View Model
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
        ///     Maps a EmployeeAccount View Model to EmployeeAccount Data Model
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static EmployeeAccount
            MapEmployeeAccount(EmployeeAccountModel account)
        {
            return new EmployeeAccount
            {
                Email = account.Email,
                Password = account.Password,
                CreatedOn = account.CreatedOn,
                UpdatedOn = account.UpdatedOn,
                IsArchived = account.IsArchived,
            };
        }
    }
}