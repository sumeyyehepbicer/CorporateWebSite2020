using AutoWrapper.Wrappers;
using CorporateWebSite.Shared.Models;
using CorporateWebSite.Shared.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Contracts
{
    public interface ISliderService
    {
        Task<ApiResponse> GetSliders();
        Task<ApiResponse> AddSlider(AddSliderRequestModel req);
        Task<ApiResponse> UpdateSlider(UpdateSliderRequestModel req);
        Task<ApiResponse> DeleteSliderById(int id);
    }
}
