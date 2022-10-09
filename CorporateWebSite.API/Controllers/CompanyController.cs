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
    public class CompanyController : BaseApiController
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("GetCompany")]
        public async Task<ApiResponse> GetCompany()
        {
            return await _companyService.GetCompanyInfo();
        }
        [HttpGet("GetContact")]
        public async Task<ApiResponse> GetContact()
        {
            return await _companyService.GetContact();
        }
        [HttpPost("SendMessage")]
        public async Task<ApiResponse> SendMessage(SendMessageRequestModel req)
        {
            return await _companyService.SendMessage(req);
        }
        [HttpPost("UpdateCompany")]
        public async Task<ApiResponse> UpdateCompany(UpdateCompanyRequestModel req)
        {
            return await _companyService.UpdateCompany(req);
        }
    }
}
