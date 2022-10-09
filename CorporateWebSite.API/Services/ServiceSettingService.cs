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
    public class ServiceSettingService : IServiceSettingService
    {
        private readonly IRepository _repository;
        public ServiceSettingService(IRepository repository)
        {
            _repository = repository;
        }


        public async Task<ApiResponse> GetServices()
        {
            try
            {
                var services = await _repository.GetListAsync<ServiceSetting>();
                //var threeService = services.Take(9);
                return new ApiResponse("Servisler başarıyla getirildi.", services, 200);
            }
            catch (Exception)
            {
                throw new ApiException("Servisler getirilirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }

        }

        public async Task<ApiResponse> GetServiceImage(int serviceId)
        {
            Specification<ServiceSetting> specification = new Specification<ServiceSetting>();
            specification.Includes = ep => ep
                .Include(e => e.ServiceImages);
            specification.Conditions.Add(s => s.Id == serviceId);
            var items = await _repository.GetListAsync(specification);
            return new ApiResponse("Servisler başarıyla getirildi.", items, 200);
        }

        public async Task<ApiResponse> GetServiceDetail(int Id)
        {
            Specification<ServiceSetting> specification = new Specification<ServiceSetting>();
            specification.Includes = ep => ep
                .Include(e => e.ServiceImages);
            specification.Conditions.Add(s => s.Id == Id);
            var items = await _repository.GetAsync(specification);
            return new ApiResponse("Servisler başarıyla getirildi.", items, 200);
        }

        public async Task<ApiResponse> GetServiceImageById(int serviceId)
        {
            Specification<ServiceImage> specification = new Specification<ServiceImage>();
            specification.Includes = ep => ep
                .Include(e => e.ServiceSetting);
            specification.Conditions.Add(s => s.ServiceSettingId == serviceId);
            var items = await _repository.GetListAsync(specification);
            return new ApiResponse("Image Detayları", items, 200);
        }

        public async Task<ApiResponse> AddService(AddServiceRequestModel req)
        {
            try
            {
                ServiceSetting addService = new()
                {
                    Title = req.Title,
                    ShortDescription = req.ShortDescription,
                    LongDescription = req.LongDescription,
                    Icon = req.Icon,
                    CoverImageUrl = string.Empty,
                    IsActive = req.IsActive
                };
                await _repository.InsertAsync<ServiceSetting>(addService);
                return new ApiResponse("Hizmet bilginiz başarılı bir şekilde eklenmiştir", addService, 200);
            }
            catch (Exception)
            {
                throw new ApiException("Hizmet bilgileri eklenirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }

        public async Task<ApiResponse> DeleteService(int Id)
        {
            var isExists = await _repository.GetByIdAsync<ServiceSetting>(Id);
            if (isExists is null)
            {
                throw new ApiException("Böyle bir bilgi bulunamadı.");
            }
            await _repository.DeleteAsync(isExists);
            return new ApiResponse($"{isExists.Title} başlıklı bilginiz silinmiştir.");
        }

        public async Task<ApiResponse> UpdateService(UpdateServiceRequestModel req)
        {
            var existService = await _repository.GetByIdAsync<ServiceSetting>(req.Id);
            if (existService is not null)
            {
                existService.CoverImageUrl = existService.CoverImageUrl;
                existService.Title = req.Title;
                existService.ShortDescription = req.ShortDescription;
                existService.LongDescription = req.LongDescription;
                existService.Icon = req.Icon;
                existService.IsActive = req.IsActive;
                await _repository.UpdateAsync(existService);
                return new ApiResponse("Hizmet bilginiz başarılı bir şekilde güncellenmiştir", existService, 200);
            }
            else
            {
                throw new ApiException("Hizmet bilgileri güncellenirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }

        public async Task<ApiResponse> DeleteServiceImageById(int Id)
        {
            var isExists = await _repository.GetByIdAsync<ServiceImage>(Id);
            if (isExists is null)
            {
                throw new ApiException("Böyle bir bilgi bulunamadı.");
            }
            await _repository.DeleteAsync(isExists);
            return new ApiResponse($"Resim silinmiştir.");
        }

        public async Task<ApiResponse> AddServiceImage(AddServiceImageRequestModel req)
        {
            try
            {
                ServiceImage addServiceImage = new()
                {
                    ImageUrl=string.Empty,
                    ServiceSettingId=req.ServiceSettingId,
                    IsActive = req.IsActive
                };
                await _repository.InsertAsync<ServiceImage>(addServiceImage);
                return new ApiResponse("Hizmet resmi başarılı bir şekilde eklenmiştir", addServiceImage, 200);
            }
            catch (Exception)
            {
                throw new ApiException("Hizmet resmi eklenirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }
    }
}
