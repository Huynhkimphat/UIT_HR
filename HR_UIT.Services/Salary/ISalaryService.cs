namespace HR_UIT.Services.Salary
{
    public interface ISalaryService
    {
        ServiceResponse<Data.Models.EmployeeSalary>
            CreateEmployeeSalary(
                Data.Models.EmployeeSalary salary
            );

        ServiceResponse<Data.Models.EmployeeSalary>
            UpdateEmployeeSalary(
                Data.Models.EmployeeSalary salary, int salaryId
            );

        ServiceResponse<Data.Models.EmployeeSalary>
            IsCheckedSalary(
                int salaryId
            );

        ServiceResponse<Data.Models.EmployeeSalary>
            IsUnCheckedSalary(
                int salaryId
            );

        ServiceResponse<Data.Models.EmployeeSalary>
            IsReceivedSalary(
                int salaryId
            );

        ServiceResponse<Data.Models.EmployeeSalary>
            IsUnReceivedSalary(
                int salaryId
            );

        ServiceResponse<bool>
            DeleteSalary(int id);

        ServiceResponse<bool>
            RecoverSalary(int id);

        Data.Models.EmployeeSalary GetEmployeeSalaryById(int id);
        Data.Models.EmployeeSalary GetEmployeeSalaryByYearMonth(int year, int month);

        ServiceResponse<bool>
            AddSalaryToEmployee(int salId, int empId);
        
        ServiceResponse<bool>
            RemoveSalaryOutOfEmployee(int salId,int empId);
    }
}