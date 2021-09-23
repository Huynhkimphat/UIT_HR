using System;
using System.Linq;
using System.Collections.Generic;
using HR_UIT.Data;

namespace HR_UIT.Services.EmployeeDayOff_Letter
{
    public abstract class EmployeeDayOffLetterService
    {
        private readonly HrUitDbContext _db;

        public EmployeeDayOffLetterService(HrUitDbContext dbContext)
        {
            _db = dbContext;
        }

        public ServiceResponse<Data.Models.EmployeeDayOffLetter>
            CreateNewEmployeeDayOffLetter(Data.Models.EmployeeDayOffLetter employeeDayOffLetter)
        {
            var now = DateTime.UtcNow;
            try
            {
                _db.EmployeeDayOffLetters.Add(employeeDayOffLetter);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.EmployeeDayOffLetter>
                {
                    Data = employeeDayOffLetter,
                    Time = now,
                    Message = "Create new EmployeeDayOffLetter",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.EmployeeDayOffLetter>
                {
                    Data = null,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

        public ServiceResponse<Data.Models.EmployeeDayOffLetter>
            UpdateEmployeeDayOffLetter(Data.Models.EmployeeDayOffLetter employeeDayOffLetter, int employeeDayOffLetterId)
        {
            var now = DateTime.UtcNow;
            var employee = _db.EmployeeDayOffLetters.Find(employeeDayOffLetterId);
            if (employee == null)
                return new ServiceResponse<Data.Models.EmployeeDayOffLetter>
                {
                    Data = null,
                    Time = now,
                    Message = "EmployeeDayOffLetter to Update Not Found",
                    IsSuccess = false
                };
            try
            {
                employee.FromDateTime = employeeDayOffLetter.FromDateTime;
                employee.ToDateTime = employeeDayOffLetter.ToDateTime;
                employee.Reason = employeeDayOffLetter.Reason;
                employee.CreatedOn = employeeDayOffLetter.CreatedOn;
                employee.DayOffCounting = employeeDayOffLetter.DayOffCounting;
                employee.UpdatedOn =employeeDayOffLetter.UpdatedOn;
                employee.IsArchived = employeeDayOffLetter.IsArchived;
                _db.EmployeeDayOffLetters.Update(employee);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.EmployeeDayOffLetter>
                {
                    Data = employee,
                    Time = now,
                    Message = $"EmployeeDayOffLetter {employee.Id}  Updated!",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.EmployeeDayOffLetter>
                {
                    Data = null,
                    Time = now,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

        public ServiceResponse<bool> DeleteEmployeeDayOffLetter(int id)
        {
            var now = DateTime.UtcNow;
            var employeeDayOffLetter = _db.EmployeeDayOffLetters.Find(id);
            if (employeeDayOffLetter == null)
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "EmployeeDayOffLetter to archive not found",
                    IsSuccess = false
                };
            try
            {
                employeeDayOffLetter.IsArchived = true;
                employeeDayOffLetter.UpdatedOn = now;
                _db.EmployeeDayOffLetters.Update(employeeDayOffLetter);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "EmployeeDayOffLetter archive",
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

        public ServiceResponse<bool> RecoverEmployeeDayOffLetter(int id)
        {
            var now = DateTime.UtcNow;
            var employeeDayOffLetter = _db.EmployeeDayOffLetters.Find(id);
            if (employeeDayOffLetter == null)
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "EmployeeDayOffLetter to recover not found",
                    IsSuccess = false
                };
            try
            {
                employeeDayOffLetter.IsArchived = false;
                employeeDayOffLetter.UpdatedOn = now;
                _db.EmployeeDayOffLetters.Update(employeeDayOffLetter);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "EmployeeDayOffLetter recover",
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

        public List<Data.Models.EmployeeDayOffLetter> GetAllEmployeeDayOffLetter()
        {
            return _db.EmployeeDayOffLetters
                .OrderBy(employeeDayOffLetter => employeeDayOffLetter.Id)
                .ToList();
        }

        public List<Data.Models.EmployeeDayOffLetter> GetAllEmployeeDayOffLetterByDay(DateTime day)
        {
            return _db.EmployeeDayOffLetters
                .Where(e => e.FromDateTime.Day == day.Day 
                            && e.FromDateTime.Month == day.Month
                            && e.FromDateTime.Year == day.Year)
                .ToList();
        }

        public List<Data.Models.EmployeeDayOffLetter> GetAllEmployeeDayOffLetterByMonth(DateTime month)
        {
            return _db.EmployeeDayOffLetters
                .Where(e => e.FromDateTime.Month == month.Month
                            && e.FromDateTime.Year == month.Year)
                .ToList();
        }
        
        public List<Data.Models.EmployeeDayOffLetter> GetAllEmployeeDayOffLetterByYear(DateTime year)
        {
            return _db.EmployeeDayOffLetters
                .Where(e => e.FromDateTime.Year == year.Year)
                .ToList();
        }
        
        public ServiceResponse<bool> ApproveEmployeeDayOffLetter(int id)
        {
            var now = DateTime.UtcNow;
            var employeeDayOffLetter = _db.EmployeeDayOffLetters.Find(id);
            if (employeeDayOffLetter == null)
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    Message = "EmployeeDayOffLetter to approve not found",
                    IsSuccess = false
                };
            try
            {
                employeeDayOffLetter.IsApproved = true;
                _db.EmployeeDayOffLetters.Update(employeeDayOffLetter);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "EmployeeDayOffLetter approve",
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