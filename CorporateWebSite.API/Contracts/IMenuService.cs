using AutoWrapper.Wrappers;
using CorporateWebSite.Shared.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Contracts
{
    public interface IMenuService
    {
        Task<ApiResponse> GetMenus();
        Task<ApiResponse> UpdateMenu(UpdateMenuRequestModel req);

    }
}
