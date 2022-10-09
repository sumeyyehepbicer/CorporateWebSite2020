using AutoWrapper.Wrappers;
using CorporateWebSite.API.Contracts;
using CorporateWebSite.API.Controllers.Common;
using CorporateWebSite.Shared.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : BaseApiController
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("GetProjects")]
        public async Task<ApiResponse> GetProjects()
        {
            return await _projectService.GetProjects();
        }

        [HttpPost("AddProject")]
        public async Task<ApiResponse> AddProject(AddProjectRequestModel req)
        {
            return await _projectService.AddProject(req);
        }
        [HttpPost("UpdateProject")]
        public async Task<ApiResponse> UpdateProject(UpdateProjectRequestModel req)
        {
            return await _projectService.UpdateProject(req);
        }


        [HttpGet("DeleteProjectById")]
        public async Task<ApiResponse> DeleteProjectById(int id)
        {
            return await _projectService.DeleteProjectById(id);
        }

        [HttpGet("GetProjectDetail")]
        public async Task<ApiResponse> GetProjectDetail(int Id)
        {
            return await _projectService.GetProjectDetail(Id);
        }

        [HttpGet("GetProjectGalleryById")]
        public async Task<ApiResponse> GetProjectGalleryById(int Id)
        {
            return await _projectService.GetProjectGalleryById(Id);
        }
        [HttpGet("GetProjectInfoById")]
        public async Task<ApiResponse> GetProjectInfoById(int Id)
        {
            return await _projectService.GetProjectInfoById(Id);
        }
        [HttpGet("DeleteProjectInfoById")]
        public async Task<ApiResponse> DeleteProjectInfoById(int Id)
        {
            return await _projectService.DeleteProjectInfoById(Id);
        }


        [HttpPost("AddProjectDetail")]
        public async Task<ApiResponse> AddProjectDetail(AddProjectDetailRequestModel req)
        {
            return await _projectService.AddProjectDetail(req);
        }
        [HttpPost("AddProjectGallery")]
        public async Task<ApiResponse> AddProjectGallery(AddProjectGalleryRequestModel req)
        {
            return await _projectService.AddProjectGallery(req);
        }
        [HttpGet("DeleteProjectGalleryById")]
        public async Task<ApiResponse> DeleteProjectGalleryById(int Id)
        {
            return await _projectService.DeleteProjectGalleryById(Id);
        }

        [HttpPost("UpdateProjectDetail")]
        public async Task<ApiResponse> UpdateProjectDetail(UpdateProjectDetailRequestModel req)
        {
            return await _projectService.UpdateProjectDetail(req);
        }

        [HttpGet("GetProjectDetailInfo")]
        public async Task<ApiResponse> GetProjectDetailInfo(int Id)
        {
            return await _projectService.GetProjectDetailInfo(Id);
        }
    }
}
