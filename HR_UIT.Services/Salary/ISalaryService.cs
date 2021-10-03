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
            CheckSalary(
                int salaryId
            );
        ServiceResponse<Data.Models.EmployeeSalary>
            ReceiveSalary(
                int salaryId
            );
        Data.Models.EmployeeSalary GetEmployeeSalaryById(int id);
        Data.Models.EmployeeSalary GetEmployeeSalaryByYearMonth(int year, int month);
    }
}