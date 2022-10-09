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
    public class CustomInfoController : BaseApiController
    {
        private readonly ICustomInfoService _customInfoService;
        public CustomInfoController(ICustomInfoService customInfoService)
        {
            _customInfoService = customInfoService;
        }

        [HttpGet("GetCustomInfo")]
        public async Task<ApiResponse> GetCustomInfo()
        {
            return await _customInfoService.GetCustomInfoes();
        }

        [HttpPost("AddCustomInfo")]
        public async Task<ApiResponse> AddCustomInfo(AddCustomInfoRequestModel req)
        {
            return await _customInfoService.AddCustomInfo(req);
        }
        [HttpPost("UpdateCustomInfo")]
        public async Task<ApiResponse> UpdateCustomInfo(UpdateCustomInfoRequestModel req)
        {
            return await _customInfoService.UpdateCustomInfo(req);
        }


        [HttpGet("DeleteCustomInfoById")]
        public async Task<ApiResponse> DeleteCustomInfoById(int id)
        {
            return await _customInfoService.DeleteCustomInfoById(id);
        }
    }
}
