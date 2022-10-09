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
    public class MenuService:IMenuService
    {
        private readonly IRepository _repository;
        public MenuService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse> GetMenus()
        {
            try
            {
                var menu = await _repository.GetListAsync<Menu>();
                return new ApiResponse("Menüler Başarılı Bir Şekilde Getirildi.", menu, 200);
            }
            catch (Exception ex)
            {

                throw new ApiException("Menüler getirilirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }

        public async Task<ApiResponse> UpdateMenu(UpdateMenuRequestModel req)
        {
            var existMenu = await _repository.GetByIdAsync<Menu>(req.Id);
            if (existMenu is not null)
            {

                existMenu.Name = req.Name;
                existMenu.IsActive = req.IsActive;
                await _repository.UpdateAsync(existMenu);
                return new ApiResponse("Menü bilginiz başarılı bir şekilde güncellenmiştir", existMenu, 200);
            }
            else
            {
                throw new ApiException("Menü bilgileri güncellenirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }
    }
}
