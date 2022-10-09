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
    public class CommentService: ICommentService
    {
        private readonly IRepository _repository;
        public CommentService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse> GetComments()
        {
            var comments = await _repository.GetListAsync<Comment>();
            return new ApiResponse("Yorumlar", comments, 200);
        }
        public async Task<ApiResponse> AddComment(AddCommentRequestModel req)
        {
            try
            {
                Comment comment = new()
                {
                    ProfileImgUrl = string.Empty,
                    EmployeeTitle=req.EmployeeTitle,
                    EmployeeName=req.EmployeeName,
                    CommentDescription=req.CommentDescription,
                    BgImgUrl= "https://i.pinimg.com/originals/0d/8e/88/0d8e88cf3645348f3d14773ac91253a9.jpg",
                    IsActive = req.IsActive
                };
                await _repository.InsertAsync<Comment>(comment);
                return new ApiResponse("Yorumlar başarılı bir şekilde eklenmiştir", comment, 200);
            }
            catch (Exception)
            {

                throw new ApiException("Yorumlar eklenirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }

        }

        public async Task<ApiResponse> DeleteComment(int Id)
        {
            var isExists = await _repository.GetByIdAsync<Comment>(Id);
            if (isExists is null)
            {
                throw new ApiException("Böyle bir bilgi bulunamadı.");
            }
            await _repository.DeleteAsync(isExists);
            return new ApiResponse($"{isExists.EmployeeName} tarafından yapılan yorum silinmiştir.");
        }

        public async Task<ApiResponse> UpdateComment(UpdateCommentRequestModel req)
        {
            var existAbout = await _repository.GetByIdAsync<Comment>(req.Id);
            if (existAbout is not null)
            {
                existAbout.ProfileImgUrl = existAbout.ProfileImgUrl;
                existAbout.EmployeeName = req.EmployeeName;
                existAbout.EmployeeTitle = req.EmployeeTitle;
                existAbout.CommentDescription = req.CommentDescription;
                existAbout.IsActive = req.IsActive;
                existAbout.BgImgUrl = "https://i.pinimg.com/originals/0d/8e/88/0d8e88cf3645348f3d14773ac91253a9.jpg";
                await _repository.UpdateAsync(existAbout);
                return new ApiResponse("Yorum başarılı bir şekilde güncellenmiştir", existAbout, 200);
            }
            else
            {
                throw new ApiException("Yorum güncellenirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }
    }
}
