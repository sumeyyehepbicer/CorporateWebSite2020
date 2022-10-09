using AutoWrapper.Wrappers;
using CorporateWebSite.API.Contracts;
using CorporateWebSite.Shared.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet("GetComments")]
        public async Task<ApiResponse> GetComments()
        {
            return await _commentService.GetComments();
        }

        [HttpPost("AddComment")]
        public async Task<ApiResponse> AddComment(AddCommentRequestModel req)
        {
            return await _commentService.AddComment(req);
        }
        [HttpPost("UpdateComment")]
        public async Task<ApiResponse> UpdateComment(UpdateCommentRequestModel req)
        {
            return await _commentService.UpdateComment(req);
        }
        [HttpGet("DeleteComment")]
        public async Task<ApiResponse> DeleteComment(int Id)
        {
            return await _commentService.DeleteComment(Id);
        }
    }
}
