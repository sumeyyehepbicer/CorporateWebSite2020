using AutoWrapper.Wrappers;
using CorporateWebSite.API.Contracts;
using CorporateWebSite.API.Entities;
using CorporateWebSite.Shared.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TanvirArjel.EFCore.GenericRepository;

namespace CorporateWebSite.API.Services
{
    public class AboutUsService: IAboutUsService
    {
        private readonly IRepository _repository;
        public AboutUsService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<ApiResponse> GetAboutUs()
        {
            try
            {
                var aboutUs = await _repository.GetListAsync<AboutUs>();
                return new ApiResponse("Hakkımda Bilgileri Başarılı Bir Şekilde Getirildi.", aboutUs.First(), 200);
            }
            catch (Exception)
            {
                throw new ApiException("Hakkımda bilgileri getirilirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }
        public async Task<ApiResponse> AddAboutUs(AddAboutUsRequestModel req)
        {
            try
            {
                AboutUs addAboutUs = new()
                {
                    Description = req.Description,
                    ImageUrl = string.Empty,
                    Title = req.Title,
                    IsActive = true
                };
                await _repository.InsertAsync<AboutUs>(addAboutUs);
                return new ApiResponse("Hakkımızda bilginiz başarılı bir şekilde eklenmiştir", addAboutUs, 200);
            }
            catch (Exception)
            {

                throw new ApiException("Hakkımda bilgileri eklenirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
            
        }
        public async Task<ApiResponse> UpdateAboutUs(UpdateAboutUsRequestModel req)
        {
            var existAbout = await _repository.GetByIdAsync<AboutUs>(req.Id);
            if (existAbout is not null)
            {
                existAbout.ImageUrl = existAbout.ImageUrl;
                existAbout.Title = req.Title;
                existAbout.Description = req.Description;
                await _repository.UpdateAsync(existAbout);
                return new ApiResponse("Hakkımızda bilginiz başarılı bir şekilde güncellenmiştir", existAbout, 200);
            }
            else
            {
                throw new ApiException("Hakkımda bilgileri güncellenirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }

        public async Task<ApiResponse> DeleteAboutUsById(int id)
        {
            var isExists = await _repository.GetByIdAsync<AboutUs>(id);
            if(isExists is null)
            {
                throw new ApiException("Böyle bir bilgi bulunamadı.");
            }
            await _repository.DeleteAsync(isExists);
            return new ApiResponse($"{isExists.Title} başlıklı bilginiz silinmiştir.");
        }

        public async Task<ApiResponse> GetAboutUsAll()
        {
            try
            {
                var aboutUsContent = await _repository.GetListAsync<AboutContent>();
                return new ApiResponse("Hakkımda Bilgileri Başarılı Bir Şekilde Getirildi.", aboutUsContent.First(), 200);
            }
            catch (Exception)
            {
                throw new ApiException("Hakkımda bilgileri getirilirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }

        public async Task<ApiResponse> UpdateAboutContent(UpdateAboutContentRequestModel req)
        {
            var existAbout = await _repository.GetByIdAsync<AboutContent>(req.Id);
            if (existAbout is not null)
            {
                
                existAbout.Title = req.Title;
                existAbout.Description = req.Description;
                existAbout.Description2 = req.Description2;
                await _repository.UpdateAsync(existAbout);
                return new ApiResponse("Hakkımızda bilginiz başarılı bir şekilde güncellenmiştir", existAbout, 200);
            }
            else
            {
                throw new ApiException("Hakkımda bilgileri güncellenirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }
    }
}
