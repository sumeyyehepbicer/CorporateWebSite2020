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
    public class MeetController : ControllerBase
    {
        private readonly IMeetService _meetService;
        public MeetController(IMeetService meetService)
        {
            _meetService = meetService;
        }
        [HttpGet("GetMeets")]
        public async Task<ApiResponse> GetMeets()
        {
            return await _meetService.GetMeets();
        }
        [HttpGet("GetFirstMeet")]
        public async Task<ApiResponse> GetFirstMeet()
        {
            return await _meetService.GetFirstMeet();
        }
        [HttpPost("AddMeet")]
        public async Task<ApiResponse> AddMeet(AddMeetRequestModel req)
        {
            return await _meetService.AddMeet(req);
        }
        [HttpGet("DeleteMeet")]
        public async Task<ApiResponse> DeleteMeet(int Id)
        {
            return await _meetService.DeleteMeet(Id);
        }

        [HttpPost("UpdateMeet")]
        public async Task<ApiResponse> UpdateMeet(UpdateMeetRequestModel req)
        {
            return await _meetService.UpdateMeet(req);
        }
    }
}
