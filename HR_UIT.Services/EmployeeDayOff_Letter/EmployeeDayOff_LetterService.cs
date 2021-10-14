using System;
using System.Linq;
using System.Collections.Generic;
using HR_UIT.Data;

namespace HR_UIT.Services.EmployeeDayOff_Letter
{
    public class EmployeeDayOffLetterService : IEmployeeDayOffLetterService
    {
        private readonly HrUitDbContext _db;

        public EmployeeDayOffLetterService(HrUitDbContext dbContext)
        {
            _db = dbContext;
        }

        /// <summary>
        /// Create New Employee DayOff Letter
        /// </summary>
        /// <param name="employeeDayOffLetter"></param>
        /// <returns></returns>
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
    
        /// <summary>
        /// Update Employee DayOff Letter With Given Id
        /// </summary>
        /// <param name="employeeDayOffLetter"></param>
        /// <param name="employeeDayOffLetterId"></param>
        /// <returns></returns>
        public ServiceResponse<Data.Models.EmployeeDayOffLetter>
            UpdateEmployeeDayOffLetter(Data.Models.EmployeeDayOffLetter employeeDayOffLetter,
                int employeeDayOffLetterId)
        {
            var now = DateTime.UtcNow;
            var newEmployeeDayOffLetter = _db.EmployeeDayOffLetters.Find(employeeDayOffLetterId);
            if (newEmployeeDayOffLetter == null)
                return new ServiceResponse<Data.Models.EmployeeDayOffLetter>
                {
                    Data = null,
                    Time = now,
                    Message = "EmployeeDayOffLetter to Update Not Found",
                    IsSuccess = false
                };
            try
            {
                newEmployeeDayOffLetter.FromDateTime = employeeDayOffLetter.FromDateTime;
                newEmployeeDayOffLetter.ToDateTime = employeeDayOffLetter.ToDateTime;
                newEmployeeDayOffLetter.Reason = employeeDayOffLetter.Reason;
                newEmployeeDayOffLetter.DayOffCounting = employeeDayOffLetter.DayOffCounting;
                newEmployeeDayOffLetter.UpdatedOn = employeeDayOffLetter.UpdatedOn;
                newEmployeeDayOffLetter.IsArchived = employeeDayOffLetter.IsArchived;
                newEmployeeDayOffLetter.IsApproved = employeeDayOffLetter.IsApproved;
                _db.EmployeeDayOffLetters.Update(newEmployeeDayOffLetter);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.EmployeeDayOffLetter>
                {
                    Data = newEmployeeDayOffLetter,
                    Time = now,
                    Message = $"EmployeeDayOffLetter {newEmployeeDayOffLetter.Id}  Updated!",
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

        /// <summary>
        /// Delete Employee DayOff With Given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                    Message = "EmployeeDayOffLetter archived",
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

        /// <summary>
        /// Recover Employee DayOff Letter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                    Message = "EmployeeDayOffLetter recovered",
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

        /// <summary>
        /// Get All Employee DayOff Letter
        /// </summary>
        /// <returns></returns>
        public List<Data.Models.EmployeeDayOffLetter> GetAllEmployeeDayOffLetter()
        {
            return _db.EmployeeDayOffLetters
                .OrderBy(employeeDayOffLetter => employeeDayOffLetter.Id)
                .ToList();
        }
        
        /// <summary>
        /// Get All Employee DayOff Letter By Given Day
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public List<Data.Models.EmployeeDayOffLetter> GetAllEmployeeDayOffLetterByDay(DateTime day)
        {
            return _db.EmployeeDayOffLetters
                .Where(e => e.FromDateTime.Day == day.Day
                            && e.FromDateTime.Month == day.Month
                            && e.FromDateTime.Year == day.Year)
                .OrderBy(employeeDayOffLetter => employeeDayOffLetter.Id)
                .ToList();
        }

        /// <summary>
        /// Get All Employee DayOff Letter By Given Month
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public List<Data.Models.EmployeeDayOffLetter> GetAllEmployeeDayOffLetterByMonth(DateTime month)
        {
            return _db.EmployeeDayOffLetters
                .Where(e => e.FromDateTime.Month == month.Month
                            && e.FromDateTime.Year == month.Year)
                .OrderBy(employeeDayOffLetter => employeeDayOffLetter.Id)
                .ToList();
        }

        /// <summary>
        /// Get All Employee DayOff Letter By Week
        /// </summary>
        /// <param name="week"></param>
        /// <returns></returns>
        public List<Data.Models.EmployeeDayOffLetter> GetAllEmployeeDayOffLetterByWeek(DateTime week)
        {
            var startOfWeek = week;
            while (startOfWeek.DayOfWeek != DayOfWeek.Monday)
                startOfWeek = startOfWeek.AddDays(-1);
            var endOfWeek = startOfWeek.AddDays(7);

            var dayOffLetter = new List<Data.Models.EmployeeDayOffLetter>();
            
            while (startOfWeek <= endOfWeek)
            {
                dayOffLetter.AddRange(GetAllEmployeeDayOffLetterByDay(startOfWeek));
                startOfWeek = startOfWeek.AddDays(1);
            }

            return dayOffLetter;
        }

        /// <summary>
        /// Approve Employee DayOff Letter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                employeeDayOffLetter.UpdatedOn = now;
                _db.EmployeeDayOffLetters.Update(employeeDayOffLetter);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    Message = "EmployeeDayOffLetter approved",
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
            