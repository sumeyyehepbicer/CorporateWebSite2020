using AutoWrapper.Wrappers;
using CorporateWebSite.API.Contracts;
using CorporateWebSite.API.Entities;
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
    public class HomePageController : ControllerBase
    {
        private readonly IHomePageService _homePageService;
        public HomePageController(IHomePageService homePageService)
        {
            _homePageService = homePageService;
        }
        [HttpGet("GetHome")]
        public async Task<ApiResponse> GetHome()
        {
            return await _homePageService.GetHome();
        }

        [HttpPost("UpdateHome")]
        public async Task<ApiResponse> UpdateHome(UpdateHomePageRequestModel req)
        {
            return await _homePageService.UpdateHome(req);
        }
    }
}
