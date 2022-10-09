using AutoWrapper.Wrappers;
using CorporateWebSite.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Contracts
{
    public interface IHomePageService
    {
        Task<ApiResponse> GetHome();
        Task<ApiResponse> UpdateHome(UpdateHomePageRequestModel req);
    }
}
