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
    public class AboutUsController : ControllerBase
    {
        private readonly IAboutUsService _aboutUsService;
        public AboutUsController(IAboutUsService aboutUsService)
        {
            _aboutUsService = aboutUsService;
        }

        [HttpGet("GetAboutUs")]
        public async Task<ApiResponse> GetAboutUs()
        {
            return await _aboutUsService.GetAboutUs();
        }

        [HttpPost("AddAboutUs")]
        public async Task<ApiResponse> AddAboutUs(AddAboutUsRequestModel req)
        {
            return await _aboutUsService.AddAboutUs(req);
        }

        [HttpPost("UpdateAboutUs")]
        public async Task<ApiResponse> UpdateAboutUs(UpdateAboutUsRequestModel req)
        {
            return await _aboutUsService.UpdateAboutUs(req);
        }
        [HttpPost("UpdateAboutContent")]
        public async Task<ApiResponse> UpdateAboutContent(UpdateAboutContentRequestModel req)
        {
            return await _aboutUsService.UpdateAboutContent(req);
        }

        [HttpGet("DeleteAboutUsById")]
        public async Task<ApiResponse> DeleteAboutUsById(int id)
        {
            return await _aboutUsService.DeleteAboutUsById(id);
        }

        [HttpGet("GetAboutUsAll")]
        public async Task<ApiResponse> GetAboutUsAll()
        {
            return await _aboutUsService.GetAboutUsAll();
        }
    }
}
