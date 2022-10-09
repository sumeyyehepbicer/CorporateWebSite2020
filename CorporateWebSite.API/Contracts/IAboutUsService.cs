using AutoWrapper.Wrappers;
using CorporateWebSite.Shared.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Contracts
{
    public interface IAboutUsService
    {
        Task<ApiResponse> GetAboutUs();
        Task<ApiResponse> GetAboutUsAll();
        Task<ApiResponse> AddAboutUs(AddAboutUsRequestModel req);
        Task<ApiResponse> UpdateAboutUs(UpdateAboutUsRequestModel req);
        Task<ApiResponse> DeleteAboutUsById(int id);
        Task<ApiResponse> UpdateAboutContent(UpdateAboutContentRequestModel req);

    }
}
