using AutoWrapper.Wrappers;
using CorporateWebSite.Shared.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Contracts
{
    public interface IPartnerService
    {
        Task<ApiResponse> GetPartners();
        Task<ApiResponse> AddPartner(AddPartnerRequestModel req);
        Task<ApiResponse> UpdatePartner(UpdatePartnerRequestModel req);
        Task<ApiResponse> DeletePartnerById(int id);
    }
}
