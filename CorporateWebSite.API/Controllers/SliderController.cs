using AutoWrapper.Wrappers;
using CorporateWebSite.API.Contracts;
using CorporateWebSite.API.Controllers.Common;
using CorporateWebSite.Shared.Models;
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
    public class SliderController : BaseApiController
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [HttpGet("GetSliders")]
        public async Task<ApiResponse> GetSliders()
        {
            return await _sliderService.GetSliders();
        }
        [HttpPost("AddSlider")]
        public async Task<ApiResponse> AddSlider(AddSliderRequestModel req)
        {
            return await _sliderService.AddSlider(req);
        }

        [HttpPost("UpdateSlider")]
        public async Task<ApiResponse> UpdateSlider(UpdateSliderRequestModel req)
        {
            return await _sliderService.UpdateSlider(req);
        }

        [HttpGet("DeleteSliderById")]
        public async Task<ApiResponse> DeleteSliderById(int id)
        {
            return await _sliderService.DeleteSliderById(id);
        }
    }
}
