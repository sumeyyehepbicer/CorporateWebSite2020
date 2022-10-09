using AutoWrapper.Wrappers;
using CorporateWebSite.Shared.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Contracts
{
    public interface IEmployeesService
    {
        Task<ApiResponse> GetEmployees();
        Task<ApiResponse> AddEmployee(AddEmployeeRequestModel req);
        Task<ApiResponse> UpdateEmployee(UpdateEmployeeRequestModel req);
        Task<ApiResponse> DeleteEmployeeById(int id);
    }
}
