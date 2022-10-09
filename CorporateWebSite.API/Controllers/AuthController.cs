using AutoWrapper.Wrappers;
using CorporateWebSite.API.Contracts;
using CorporateWebSite.Shared.Models.RequestModels;
using Microsoft.AspNetCore.Authorization;
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
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpPost("CreateUser")]
        public async Task<ApiResponse> CreateUser(CreateUserRequestModel req)
        {
            return await _authService.CreateUser(req);
        }

        [HttpPost("Login")]
        public async Task<ApiResponse> Login(LoginRequestModel req)
        {
            return await _authService.Login(req);
        }
    }
}
