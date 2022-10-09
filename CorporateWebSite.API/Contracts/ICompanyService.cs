using AutoWrapper.Wrappers;
using CorporateWebSite.Shared.Models.RequestModels;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Contracts
{
    public interface ICompanyService
    {
        Task<ApiResponse> GetCompanyInfo();
        Task<ApiResponse> SendMessage(SendMessageRequestModel req);
        Task<ApiResponse> UpdateCompany(UpdateCompanyRequestModel req);
        Task<ApiResponse> GetContact();

    }
}
