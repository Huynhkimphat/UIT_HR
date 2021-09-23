using System;
using System.Collections.Generic;

namespace HR_UIT.Web.ViewModels
{
    public class EmployeeTypeModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
        
        public bool IsArchived { get; set; }

        public List<EmployeeModel> Employees { get; set; }
    }
}