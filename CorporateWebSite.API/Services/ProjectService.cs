using AutoWrapper.Wrappers;
using CorporateWebSite.API.Contracts;
using CorporateWebSite.API.Entities;
using CorporateWebSite.Shared.Models.RequestModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TanvirArjel.EFCore.GenericRepository;

namespace CorporateWebSite.API.Services
{
    public class ProjectService: IProjectService
    {
        private readonly IRepository _repository;
        public ProjectService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<ApiResponse> GetProjects()
        {
            try
            {
                var projects = await _repository.GetListAsync<Project>();
                return new ApiResponse("Projeler Başarılı Bir Şekilde Getirildi.", projects, 200);
            }
            catch (Exception)
            {
                throw new ApiException("Projeler getirilirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }

        public async Task<ApiResponse> AddProject(AddProjectRequestModel req)
        {
            try
            {
                Project project = new()
                {
                    Description = req.Description,
                    ImageUrl = string.Empty,
                    Title = req.Title
                };
                await _repository.InsertAsync<Project>(project);
                return new ApiResponse("Projeniz başarılı bir şekilde eklenmiştir", project, 200);
            }
            catch (Exception)
            {
                throw new ApiException("Projeniz eklenirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }
      
        public async Task<ApiResponse> UpdateProject(UpdateProjectRequestModel req)
        {
            var existProject = await _repository.GetByIdAsync<Project>(req.Id);
            if(existProject is not null)
            {
                existProject.Title = req.Title;
                existProject.ImageUrl = existProject.ImageUrl;
                existProject.Description = req.Description;
                existProject.IsActive = req.IsActive;
                await _repository.UpdateAsync(existProject);
                return new ApiResponse("Projeniz başarılı bir şekilde güncellenmiştir.", existProject, 200);
            }
            else
            {
                throw new ApiException("Projeniz güncellenirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }
        public async Task<ApiResponse> DeleteProjectById(int id)
        {
            var isExists = await _repository.GetByIdAsync<Project>(id);
            if (isExists is null)
            {
                throw new ApiException("Böyle bir proje bulunamadı.");
            }
            await _repository.DeleteAsync(isExists);
            return new ApiResponse($"{isExists.Title} adlı proje silinmiştir.");
        }

        public async Task<ApiResponse> GetProjectDetail(int Id)
        {
            //var projectDetailById = await _repository.GetByIdAsync<Project>(Id);
            var projectDetailById = await _repository.GetListAsync<ProjectInfo>();
            var x = projectDetailById.Where(s=>s.ProjectId==Id);
            return new ApiResponse("Proje detayı", x, 200);
            //return new ApiResponse("Proje detayı",projectDetailById,200);
        }

        public async Task<ApiResponse> GetProjectGalleryById(int Id)
        {
            Specification<ProjectGallery> specification = new Specification<ProjectGallery>();
            specification.Includes = ep => ep
                .Include(e => e.Project);
            specification.Conditions.Add(s => s.ProjectId == Id);
            var items = await _repository.GetListAsync(specification);
            return new ApiResponse("Proje galerisi", items, 200);
        }

        public async Task<ApiResponse> GetProjectInfoById(int Id)
        {
            Specification<ProjectInfo> specification = new Specification<ProjectInfo>();
            specification.Includes = ep => ep
                .Include(e => e.Project);
            specification.Conditions.Add(s => s.ProjectId == Id);
            var items = await _repository.GetListAsync(specification);
            return new ApiResponse("Proje bilgileri", items, 200);
        }

        public async Task<ApiResponse> DeleteProjectInfoById(int Id)
        {
            var isExists = await _repository.GetByIdAsync<ProjectInfo>(Id);
            if (isExists is null)
            {
                throw new ApiException("Böyle bir proje bulunamadı.");
            }
            await _repository.DeleteAsync(isExists);
            return new ApiResponse($"{isExists.Label} adlı proje silinmiştir.");
        }
        public async Task<ApiResponse> AddProjectDetail(AddProjectDetailRequestModel req)
        {
            try
            {
                ProjectInfo projectInfo = new()
                {
                    Description = req.Description,
                    ProjectId=req.ProjectId,
                    Label = req.Label,
                    IsActive= req.IsActive
                };
                await _repository.InsertAsync<ProjectInfo>(projectInfo);
                return new ApiResponse("Proje detayı başarılı bir şekilde eklenmiştir", projectInfo, 200);
            }
            catch (Exception)
            {
                throw new ApiException("Proje detayı eklenirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }

        public async Task<ApiResponse> AddProjectGallery(AddProjectGalleryRequestModel req)
        {
            try
            {
                ProjectGallery projectGallery = new()
                {
                    
                    ProjectId = req.ProjectId,
                    ImageUrl = string.Empty,
                    IsActive = true
                };
                await _repository.InsertAsync<ProjectGallery>(projectGallery);
                return new ApiResponse("Resim galeriye başarılı bir şekilde eklenmiştir", projectGallery, 200);
            }
            catch (Exception)
            {
                throw new ApiException("Resim galeriye eklenirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }

        public async Task<ApiResponse> DeleteProjectGalleryById(int Id)
        {
            var isExists = await _repository.GetByIdAsync<ProjectGallery>(Id);
            if (isExists is null)
            {
                throw new ApiException("Böyle bir resim bulunamadı.");
            }
            await _repository.DeleteAsync(isExists);
            return new ApiResponse($"Resim silinmiştir.");
        }
        public async Task<ApiResponse> UpdateProjectDetail(UpdateProjectDetailRequestModel req)
        {
            var existProject = await _repository.GetByIdAsync<ProjectInfo>(req.Id);
            if (existProject is not null)
            {
                existProject.Label = req.Label;
                existProject.Description = req.Description;
                existProject.ProjectId = req.ProjectId;
                existProject.IsActive = req.IsActive;
                await _repository.UpdateAsync(existProject);
                return new ApiResponse("Proje detayınız başarılı bir şekilde güncellenmiştir.", existProject, 200);
            }
            else
            {
                throw new ApiException("Proje detayınız güncellenirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }

        public async Task<ApiResponse> GetProjectDetailInfo(int Id)
        {
            var projectDetailById = await _repository.GetByIdAsync<Project>(Id);
            return new ApiResponse("Proje detayı", projectDetailById, 200);
        }
    }
}
