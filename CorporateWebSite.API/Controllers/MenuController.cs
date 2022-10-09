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
    public class MenuController : BaseApiController
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet("GetMenus")]
        public async Task<ApiResponse> GetMenus()
        {
            return await _menuService.GetMenus();
        }
        [HttpPost("UpdateMenu")]
        public async Task<ApiResponse> UpdateMenu(UpdateMenuRequestModel req)
        {
            return await _menuService.UpdateMenu(req);
        }
    }
}
