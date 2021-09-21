using HR_UIT.Data.Models;
using HR_UIT.Web.ViewModels;

namespace HR_UIT.Web.Serialization
{
    public class EmployeeAddressMapper
    {
        /// <summary>
        ///     Maps a EmployeeAddress data model to a EmployeeAddressModel view model
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static EmployeeAddressModel
            MapEmployeeAddress(EmployeeAddress address)
        {
            return new EmployeeAddressModel
            {
                Id = address.Id,
                AddressLine = address.AddressLine,
                Ward = address.Ward,
                District = address.District,
                City = address.City,
                Country = address.Country,
                CreatedOn = address.CreatedOn,
                UpdatedOn = address.UpdatedOn
            };
        }

        /// <summary>
        ///     Maps a EmployeeAddressModel view model to a EmployeeAddress data model
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        private static EmployeeAddress
            MapEmployeeAddress(EmployeeAddressModel address)
        {
            return new EmployeeAddress
            {
                AddressLine = address.AddressLine,
                Ward = address.Ward,
                District = address.District,
                City = address.City,
                Country = address.Country,
                CreatedOn = address.CreatedOn,
                UpdatedOn = address.UpdatedOn
            };
        }
    }
}