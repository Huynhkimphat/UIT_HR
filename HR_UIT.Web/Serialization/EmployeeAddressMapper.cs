using HR_UIT.Data.Models;
using HR_UIT.Web.ViewModels;

namespace HR_UIT.Web.Serialization
{
    public static class EmployeeAddressMapper
    {
        /// <summary>
        ///     Maps an EmployeeAddress data model to an EmployeeAddressModel view model
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
        ///     Maps an EmployeeAddressModel view model to an EmployeeAddress data model
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static EmployeeAddress
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