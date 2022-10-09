using AutoWrapper.Wrappers;
using CorporateWebSite.API.Contracts;
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
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("GetBlogs")]
        public async Task<ApiResponse> GetBlogs()
        {
            return await _blogService.GetBlogs();
        }
        [HttpGet("GetBlogAll")]
        public async Task<ApiResponse> GetBlogAll()
        {
            return await _blogService.GetBlogAll();
        }
        [HttpGet("GetBlogById")]
        public async Task<ApiResponse> GetBlogById(int Id)
        {
            return await _blogService.GetBlogById(Id);
        }
    }
}
