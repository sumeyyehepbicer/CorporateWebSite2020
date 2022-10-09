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
    public class CompanyService:ICompanyService
    {        
        private readonly IRepository _repository;
        public CompanyService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse> GetCompanyInfo()
        {
            try
            {
                var companyInfo = await _repository.GetListAsync<Company>();
                return new ApiResponse("Şirket Bilgileri Başarılı Bir Şekilde Getirildi.", companyInfo.First(), 200);
            }
            catch (Exception ex)
            {

                throw new ApiException("Şirket bilgileriniz getirilirken bir hata oluştu.Lütfen tekrar deneyiniz.",400);
            }
        }

        public async Task<ApiResponse> GetContact()
        {
            try
            {
                var contact = await _repository.GetListAsync<Contact>();
                return new ApiResponse("İletişim Bilgileriniz Başarılı Bir Şekilde Getirildi.", contact, 200);
            }
            catch (Exception ex)
            {

                throw new ApiException("İletişim bilgileriniz getirilirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }

        public async Task<ApiResponse> SendMessage(SendMessageRequestModel req)
        {
            try
            {
                Contact contact = new()
                {
                    FullName = req.FullName,
                    Email = req.Email,
                    Message = req.Message,
                    IsActive = true
                };
                await _repository.InsertAsync<Contact>(contact);
                return new ApiResponse("Mesaj gönderildi.", contact, 200);
            }
            catch (Exception)
            {

                throw new ApiException("Mesaj gönderilirken bir hata oluştu.");
            }
           
        }

        public async Task<ApiResponse> UpdateCompany(UpdateCompanyRequestModel req)
        {
            var existCompany = await _repository.GetByIdAsync<Company>(req.Id);
            if (existCompany is not null)
            {
                existCompany.Name = req.Name;
                existCompany.PhoneNumber = req.PhoneNumber;
                existCompany.EmailAddress = req.EmailAddress;
                existCompany.Address = req.Address;
                existCompany.MapLink = req.MapLink;
                existCompany.FacebookLink = req.FacebookLink;
                existCompany.TwitterLink = req.TwitterLink;
                existCompany.LinkedlnLink = req.LinkedlnLink;
                existCompany.Logo = existCompany.Logo;
                await _repository.UpdateAsync(existCompany);
                return new ApiResponse("Şirket bilginiz başarılı bir şekilde güncellenmiştir", existCompany, 200);
            }
            else
            {
                throw new ApiException("Şirket bilgileri güncellenirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }
    }
}
