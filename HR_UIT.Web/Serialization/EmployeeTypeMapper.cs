﻿using System.Linq;
using HR_UIT.Data.Models;
using HR_UIT.Web.ViewModels;

namespace HR_UIT.Web.Serialization
{
    public class EmployeeTypeMapper
    {
        /// <summary>
        ///     Maps EmployeeType Data Model to EmployeeType View Model
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static EmployeeTypeModel
            MapEmployeeType(EmployeeType type)
        {
            return new EmployeeTypeModel
            {
                Id = type.Id,
                Name = type.Name,
                CreatedOn = type.CreatedOn,
                UpdatedOn = type.UpdatedOn,
                IsArchived = type.IsArchived,
                Employees = type.Employees
                    .Select(EmployeeMapper.MapEmployee)
                    .OrderByDescending(employee => employee.Id)
                    .ToList(),
            };
        }

        public static EmployeeType
            MapEmployeeType(EmployeeTypeModel type)
        {
            return new EmployeeType
            {
                Name = type.Name,
                CreatedOn = type.CreatedOn,
                UpdatedOn = type.UpdatedOn,
                IsArchived = type.IsArchived,
                Employees = type.Employees
                    .Select(EmployeeMapper.MapEmployee)
                    .OrderByDescending(employee => employee.Id)
                    .ToList(),
            };
        }
    }
}