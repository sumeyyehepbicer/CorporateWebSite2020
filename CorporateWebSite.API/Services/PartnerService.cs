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
    public class PartnerService:IPartnerService
    {
        public readonly IRepository _repository;
        public PartnerService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<ApiResponse> GetPartners()
        {
            try
            {
                var partners = await _repository.GetListAsync<Partner>();
                return new ApiResponse("İş Ortakları Başarılı Bir Şekilde Getirildi.", partners, 200);
            }
            catch (Exception)
            {
                throw new ApiException("İş ortakları getirilirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }
        public async Task<ApiResponse> AddPartner(AddPartnerRequestModel req)
        {
            try
            {
                Partner partner = new()
                {
                    Logo = string.Empty,
                    Name = req.Name,
                    IsActive = req.IsActive

                };
                await _repository.InsertAsync<Partner>(partner);
                return new ApiResponse("İş ortağınız başarılı bir şekilde eklenmiştir", partner, 200);
            }
            catch (Exception)
            {
                throw new ApiException("İş ortağınız eklenirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }              
        public async Task<ApiResponse> UpdatePartner(UpdatePartnerRequestModel req)
        {
            var existPartner = await _repository.GetByIdAsync<Partner>(req.Id);
            if(existPartner is not null)
            {
                existPartner.Logo = existPartner.Logo;
                existPartner.Name = req.Name;
                existPartner.IsActive = req.IsActive;
                await _repository.UpdateAsync(existPartner);
                return new ApiResponse("İş ortağınız başarılı bir şekilde güncellenmiştir.", existPartner, 200);
            }
            else
            {
                throw new ApiException("İş ortağınız güncellenirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }
        public async Task<ApiResponse> DeletePartnerById(int id)
        {
            var isExists = await _repository.GetByIdAsync<Partner>(id);
            if (isExists is null)
            {
                throw new ApiException("Böyle bir iş ortağı bulunamadı.");
            }
            await _repository.DeleteAsync(isExists);
            return new ApiResponse($"{isExists.Name} adlı iş ortağı silinmiştir.");
        }
    }
}
