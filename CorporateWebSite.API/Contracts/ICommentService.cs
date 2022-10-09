using AutoWrapper.Wrappers;
using CorporateWebSite.Shared.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Contracts
{
    public interface ICommentService
    {
        Task<ApiResponse> GetComments();
        Task<ApiResponse> AddComment(AddCommentRequestModel req);
        Task<ApiResponse> UpdateComment(UpdateCommentRequestModel req);
        Task<ApiResponse> DeleteComment(int Id);

    }
}
