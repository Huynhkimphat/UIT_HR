using System;
using System.ComponentModel.DataAnnotations;

namespace HR_UIT.Web.ViewModels
{
    public class EmployeeAddressModel
    {
        public int Id { get; set; }

        [MaxLength(100)] public string AddressLine { get; set; }

        [MaxLength(100)] public string Ward { get; set; }

        [MaxLength(100)] public string District { get; set; }

        [MaxLength(100)] public string City { get; set; }

        [MaxLength(100)] public string Country { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}