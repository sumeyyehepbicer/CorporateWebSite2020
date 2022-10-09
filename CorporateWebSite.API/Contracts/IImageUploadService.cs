using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Contracts
{
    public interface IImageUploadService
    {
        Task<ApiResponse> AddImageUrlAboutUs(IFormFile file, int Id);
        Task<ApiResponse> AddImageUrlCompany(IFormFile file, int Id);
        Task<ApiResponse> AddImageUrlCustomInfo(IFormFile file, int Id);
        Task<ApiResponse> AddImageUrlEmployee(IFormFile file, int Id);
        Task<ApiResponse> AddImageUrlPartner(IFormFile file, int Id);
        Task<ApiResponse> AddImageUrlProject(IFormFile file, int Id);
        Task<ApiResponse> AddImageUrlProjectGallery(IFormFile file, int Id);
        Task<ApiResponse> AddImageUrlSlider(IFormFile file, int Id);
        Task<ApiResponse> AddImageUrlService(IFormFile file, int Id);
        Task<ApiResponse> AddFirstImageUrlAboutUs(IFormFile file, int Id);
        Task<ApiResponse> AddSecondImageUrlAboutUs(IFormFile file, int Id);
        Task<ApiResponse> AddImageUrlMeet(IFormFile file, int Id);
        Task<ApiResponse> AddImageUrlComment(IFormFile file, int Id);
        Task<ApiResponse> AddImageUrlServiceImage(IFormFile file, int Id);



    }
}
