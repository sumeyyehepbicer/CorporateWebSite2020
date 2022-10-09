using AutoWrapper.Wrappers;
using CorporateWebSite.Shared.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Contracts
{
    public interface IMeetService
    {
        Task<ApiResponse> GetMeets();
        Task<ApiResponse> GetFirstMeet();
        Task<ApiResponse> AddMeet(AddMeetRequestModel req);
        Task<ApiResponse> UpdateMeet(UpdateMeetRequestModel req);
        Task<ApiResponse> DeleteMeet(int Id);

    }
}
