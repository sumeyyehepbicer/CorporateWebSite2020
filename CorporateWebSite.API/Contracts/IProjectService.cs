using AutoWrapper.Wrappers;
using CorporateWebSite.Shared.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Contracts
{
    public interface IProjectService
    {
        Task<ApiResponse> GetProjects();
        Task<ApiResponse> GetProjectDetail(int Id);
        Task<ApiResponse> GetProjectDetailInfo(int Id);
        Task<ApiResponse> AddProject(AddProjectRequestModel req);
        Task<ApiResponse> UpdateProject(UpdateProjectRequestModel req);
        Task<ApiResponse> DeleteProjectById(int id);
        Task<ApiResponse> GetProjectGalleryById(int Id);
        Task<ApiResponse> GetProjectInfoById(int Id);
        Task<ApiResponse> DeleteProjectInfoById(int id);
        Task<ApiResponse> AddProjectDetail(AddProjectDetailRequestModel req);
        Task<ApiResponse> AddProjectGallery(AddProjectGalleryRequestModel req);
        Task<ApiResponse> DeleteProjectGalleryById(int Id);
        Task<ApiResponse> UpdateProjectDetail(UpdateProjectDetailRequestModel req);

    }
}
