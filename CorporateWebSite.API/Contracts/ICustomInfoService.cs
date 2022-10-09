using AutoWrapper.Wrappers;
using CorporateWebSite.Shared.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Contracts
{
    public interface ICustomInfoService
    {
        Task<ApiResponse> GetCustomInfoes();
        Task<ApiResponse> AddCustomInfo(AddCustomInfoRequestModel req);
        Task<ApiResponse> UpdateCustomInfo(UpdateCustomInfoRequestModel req);
        Task<ApiResponse> DeleteCustomInfoById(int id);
    }
}
