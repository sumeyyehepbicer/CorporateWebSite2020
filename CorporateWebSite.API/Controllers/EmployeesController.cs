using AutoWrapper.Wrappers;
using CorporateWebSite.API.Contracts;
using CorporateWebSite.API.Controllers.Common;
using CorporateWebSite.Shared.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseApiController
    {
        private readonly IEmployeesService _employeesService;
        public EmployeesController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }
        [HttpGet("GetEmployees")]
        public async Task<ApiResponse> GetEmployees()
        {
            return await _employeesService.GetEmployees();
        }

        [HttpPost("AddEmployee")]
        public async Task<ApiResponse> AddEmployee(AddEmployeeRequestModel req)
        {
            return await _employeesService.AddEmployee(req);
        }
        [HttpPost("UpdateEmployee")]
        public async Task<ApiResponse> UpdateEmployee(UpdateEmployeeRequestModel req)
        {
            return await _employeesService.UpdateEmployee(req);
        }


        [HttpGet("DeleteEmployeeById")]
        public async Task<ApiResponse> DeleteEmployeeById(int id)
        {
            return await _employeesService.DeleteEmployeeById(id);
        }
    }
}
