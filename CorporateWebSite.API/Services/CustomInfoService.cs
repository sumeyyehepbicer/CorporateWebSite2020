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
    public class CustomInfoService : ICustomInfoService
    {
        private readonly IRepository _repository;
        public CustomInfoService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse> GetCustomInfoes()
        {
            try
            {
                var customInfo = await _repository.GetListAsync<CustomInfo>();
                return new ApiResponse("Şirket Özel Bilgileri Başarılı Bir Şekilde Getirildi.", customInfo, 200);
            }
            catch (Exception)
            {
                throw new ApiException("Şirket özel bilgileri getirilirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }
        public async Task<ApiResponse> AddCustomInfo(AddCustomInfoRequestModel req)
        {
            try
            {
                CustomInfo customInfo = new()
                {
                    BgImageUrl= string.Empty,
                Count = req.Count,
                    Icon = string.Empty,
                    Name = req.Name,
                    Visible = req.Visible,
                    IsActive=req.IsActive
                };
                await _repository.InsertAsync<CustomInfo>(customInfo);
                return new ApiResponse("Bilginiz başarılı bir şekilde eklenmiştir", customInfo, 200);
            }
            catch (Exception)
            {

                throw new ApiException("Bilgiler eklenirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }

        public async Task<ApiResponse> UpdateCustomInfo(UpdateCustomInfoRequestModel req)
        {
            var existAbout = await _repository.GetByIdAsync<CustomInfo>(req.Id);
            if (existAbout is not null)
            {
                existAbout.Icon = existAbout.Icon;
                existAbout.Name = req.Name;
                existAbout.IsActive = req.IsActive;
                existAbout.Count = req.Count;
                existAbout.BgImageUrl = string.Empty;
                await _repository.UpdateAsync(existAbout);
                return new ApiResponse("Bilginiz başarılı bir şekilde güncellenmiştir", existAbout, 200);
            }
            else
            {
                throw new ApiException("Bilginiz güncellenirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }

        public async Task<ApiResponse> DeleteCustomInfoById(int id)
        {
            var isExists = await _repository.GetByIdAsync<CustomInfo>(id);
            if (isExists is null)
            {
                throw new ApiException("Böyle bir bilgi bulunamadı.");
            }
            await _repository.DeleteAsync(isExists);
            return new ApiResponse($"Size özel bilginiz silinmiştir.");
        }
    }
}
