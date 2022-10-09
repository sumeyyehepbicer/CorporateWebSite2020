using AutoWrapper.Wrappers;
using CorporateWebSite.Shared.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Contracts
{
    public interface IServiceSettingService
    {
        Task<ApiResponse> GetServices();
        Task<ApiResponse> GetServiceDetail(int Id);
        Task<ApiResponse> GetServiceImage(int serviceId);
        Task<ApiResponse> GetServiceImageById(int serviceId);
        Task<ApiResponse> AddService(AddServiceRequestModel req);
        Task<ApiResponse> DeleteService(int Id);
        Task<ApiResponse> UpdateService(UpdateServiceRequestModel req);
        Task<ApiResponse> DeleteServiceImageById(int Id);
        Task<ApiResponse> AddServiceImage(AddServiceImageRequestModel req);



    }
}
