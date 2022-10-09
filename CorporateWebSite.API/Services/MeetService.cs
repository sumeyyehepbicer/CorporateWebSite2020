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
    public class MeetService: IMeetService
    {
        private readonly IRepository _repository;
        public MeetService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse> AddMeet(AddMeetRequestModel req)
        {
            try
            {
                Meet meet = new()
                {
                    Description = req.Description,
                    MeetImageUrl = string.Empty,
                    Title = req.Title,
                    IsActive = req.IsActive
                };
                await _repository.InsertAsync<Meet>(meet);
                return new ApiResponse("Tanışma bilginiz başarılı bir şekilde eklenmiştir", meet, 200);
            }
            catch (Exception)
            {

                throw new ApiException("Tanışma bilgileri eklenirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }

        public async Task<ApiResponse> DeleteMeet(int Id)
        {

            var isExists = await _repository.GetByIdAsync<Meet>(Id);
            if (isExists is null)
            {
                throw new ApiException("Böyle bir bilgi bulunamadı.");
            }
            await _repository.DeleteAsync(isExists);
            return new ApiResponse($"{isExists.Title} başlıklı bilginiz silinmiştir.");
        }

        public async Task<ApiResponse> GetFirstMeet()
        {
            var meets = await _repository.GetListAsync<Meet>();
            var firstMeet = meets.First();
            return new ApiResponse("GetMeets", firstMeet, 200);
        }

        public async Task<ApiResponse> GetMeets()
        {
            var meets = await _repository.GetListAsync<Meet>();
            return new ApiResponse("GetMeets",meets,200);
        }

        public async Task<ApiResponse> UpdateMeet(UpdateMeetRequestModel req)
        {
            var existAbout = await _repository.GetByIdAsync<Meet>(req.Id);
            if (existAbout is not null)
            {
                existAbout.MeetImageUrl = existAbout.MeetImageUrl;
                existAbout.Title = req.Title;
                existAbout.Description = req.Description;
                existAbout.IsActive = req.IsActive;
                await _repository.UpdateAsync(existAbout);
                return new ApiResponse("Tanışma formunuz başarılı bir şekilde güncellenmiştir", existAbout, 200);
            }
            else
            {
                throw new ApiException("Tanışma formunuz güncellenirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }
    }
}
