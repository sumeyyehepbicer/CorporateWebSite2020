using AutoWrapper.Wrappers;
using CorporateWebSite.API.Contracts;
using CorporateWebSite.API.Entities;
using CorporateWebSite.Shared.Models;
using CorporateWebSite.Shared.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TanvirArjel.EFCore.GenericRepository;

namespace CorporateWebSite.API.Services
{
    public class SliderService : ISliderService
    {
        private readonly IRepository _repository;
        public SliderService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse> AddSlider(AddSliderRequestModel req)
        {
            try
            {
                Slider slider = new()
                {
                    Description = req.Description,
                    ImageUrl = string.Empty,
                    Title = req.Title,
                    IsActive = true
                };
                await _repository.InsertAsync<Slider>(slider);
                return new ApiResponse("Slider bilginiz başarılı bir şekilde eklenmiştir", slider, 200);
            }
            catch (Exception)
            {

                throw new ApiException("Slider bilgileri eklenirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }

        public async Task<ApiResponse> DeleteSliderById(int id)
        {
            var isExists = await _repository.GetByIdAsync<Slider>(id);
            if (isExists is null)
            {
                throw new ApiException("Böyle bir bilgi bulunamadı.");
            }
            await _repository.DeleteAsync(isExists);
            return new ApiResponse($"{isExists.Title} başlıklı bilginiz silinmiştir.");
        }

        public async Task<ApiResponse> GetSliders()
        {
            try
            {
                var sliders = await _repository.GetListAsync<Slider>();
                return new ApiResponse("Sliderlar Başarılı Bir Şekilde Getirildi.", sliders, 200);
            }
            catch (Exception ex)
            {

                throw new ApiException("Sliderlar getirilirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
            
        }

        public async Task<ApiResponse> UpdateSlider(UpdateSliderRequestModel req)
        {
            var existSlider = await _repository.GetByIdAsync<Slider>(req.Id);
            if (existSlider is not null)
            {
                existSlider.ImageUrl = existSlider.ImageUrl;
                existSlider.Title = req.Title;
                existSlider.Description = req.Description;
                existSlider.IsActive = req.IsActive;
                await _repository.UpdateAsync(existSlider);
                return new ApiResponse("Slider bilginiz başarılı bir şekilde güncellenmiştir", existSlider, 200);
            }
            else
            {
                throw new ApiException("Slider bilgileri güncellenirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }
    }
}
