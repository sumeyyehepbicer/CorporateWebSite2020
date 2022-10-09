using AutoWrapper.Wrappers;
using CorporateWebSite.API.Contracts;
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
    public class ServiceSettingController : ControllerBase
    {
        private readonly IServiceSettingService _serviceSettingService;
        public ServiceSettingController(IServiceSettingService serviceSettingService)
        {
            _serviceSettingService = serviceSettingService;
        }

        [HttpGet("GetServices")]
        public async Task<ApiResponse> GetServices()
        {
            return await _serviceSettingService.GetServices();
        }
        [HttpGet("GetServiceImage")]
        public async Task<ApiResponse> GetServiceImage(int serviceId)
        {
            return await _serviceSettingService.GetServiceImage(serviceId);
        }
        [HttpGet("GetServiceDetail")]
        public async Task<ApiResponse> GetServiceDetail(int Id)
        {
            return await _serviceSettingService.GetServiceDetail(Id);
        }

        [HttpGet("GetServiceImageById")]
        public async Task<ApiResponse> GetServiceImageById(int serviceId)
        {
            return await _serviceSettingService.GetServiceImageById(serviceId);
        }

        [HttpPost("AddService")]
        public async Task<ApiResponse> AddService(AddServiceRequestModel req)
        {
            return await _serviceSettingService.AddService(req);
        }
        [HttpGet("DeleteService")]
        public async Task<ApiResponse> DeleteService(int Id)
        {
            return await _serviceSettingService.DeleteService(Id);
        }
        [HttpPost("UpdateService")]
        public async Task<ApiResponse> UpdateService(UpdateServiceRequestModel req)
        {
            return await _serviceSettingService.UpdateService(req);
        }
        [HttpGet("DeleteServiceImageById")]
        public async Task<ApiResponse> DeleteServiceImageById(int Id)
        {
            return await _serviceSettingService.DeleteServiceImageById(Id);
        }
        [HttpPost("AddServiceImage")]
        public async Task<ApiResponse> AddServiceImage(AddServiceImageRequestModel req)
        {
            return await _serviceSettingService.AddServiceImage(req);
        }
    }
}
