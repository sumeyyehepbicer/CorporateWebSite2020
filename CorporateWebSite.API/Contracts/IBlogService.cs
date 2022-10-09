using AutoWrapper.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Contracts
{
    public interface IBlogService
    {
        Task<ApiResponse> GetBlogs();
        Task<ApiResponse> GetBlogAll();
        Task<ApiResponse> GetBlogById(int Id);
    }
}
