using AutoWrapper.Wrappers;
using CorporateWebSite.API.Contracts;
using CorporateWebSite.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TanvirArjel.EFCore.GenericRepository;

namespace CorporateWebSite.API.Services
{
    public class BlogService: IBlogService
    {
        private readonly IRepository _repository;
        public BlogService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse> GetBlogAll()
        {
            var blogAll = await _repository.GetListAsync<Blog>();
            return new ApiResponse("Bloglar", blogAll, 200);
        }

        public async Task<ApiResponse> GetBlogById(int Id)
        {
            Specification<Blog> specification = new Specification<Blog>();
            specification.Conditions.Add(s => s.Id == Id);
            var item = await _repository.GetAsync(specification);
            return new ApiResponse("Blog detayı başarıyla getirildi.", item, 200);
        }

        public async Task<ApiResponse> GetBlogs()
        {
            var blogs = await _repository.GetListAsync<Blog>();
            var threeBlog = blogs.Take(3);
            return new ApiResponse("Bloglar",threeBlog,200);
        }
    }
}
