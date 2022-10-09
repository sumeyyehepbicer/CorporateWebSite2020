using AutoWrapper.Wrappers;
using CorporateWebSite.API.Contracts;
using CorporateWebSite.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TanvirArjel.EFCore.GenericRepository;

namespace CorporateWebSite.API.Services
{
    public class HomePageService:IHomePageService
    {
        public readonly IRepository _repository;
        public HomePageService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse> GetHome()
        {
            var home = await _repository.GetListAsync<HomePageVisibilty>();            
            return new ApiResponse("Bilgiler Başarılı Bir Şekilde Getirildi.", home, 200);
        }

        public async Task<ApiResponse> UpdateHome(UpdateHomePageRequestModel req)
        {
            var existHome = await _repository.GetByIdAsync<HomePageVisibilty>(req.Id);
            if (existHome is not null)
            {

                existHome.SliderVis = req.SliderVis;
                existHome.ServiceVis = req.ServiceVis;
                existHome.BandVis = req.BandVis;
                existHome.AboutVis = req.AboutVis;
                existHome.ProjectVis = req.ProjectVis;
                existHome.NotifyVis = req.NotifyVis;
                existHome.CommentVis = req.CommentVis;
                existHome.BlogVis = req.BlogVis;
                existHome.BrandVis = req.BrandVis;
                existHome.FooterVis = req.FooterVis;
                await _repository.UpdateAsync(existHome);
                return new ApiResponse("Başarılı bir şekilde güncellenmiştir", existHome, 200);
            }
            else
            {
                throw new ApiException("Bilgiler güncellenirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }
    }
}
