using AutoWrapper.Wrappers;
using CorporateWebSite.API.Contracts;
using CorporateWebSite.API.Controllers.Common;
using Microsoft.AspNetCore.Hosting;
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
    public class ImageUploadController : BaseApiController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IImageUploadService _imageUploadService;

        public ImageUploadController(IImageUploadService imageUploadService,
            IWebHostEnvironment webHostEnvironment)
        {
            _imageUploadService = imageUploadService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("AddImageUrlAboutUs")]
        public async Task<ApiResponse> AddImageUrlAboutUs(IFormFile file, int Id)
        {
            return await _imageUploadService.AddImageUrlAboutUs(file,Id);
        }
        

        [HttpPost("AddImageUrlEmployee")]
        public async Task<ApiResponse> AddImageUrlEmployee(IFormFile file, int Id)
        {
            return await _imageUploadService.AddImageUrlEmployee(file, Id);
        }

        [HttpPost("AddImageUrlProject")]
        public async Task<ApiResponse> AddImageUrlProject(IFormFile file, int Id)
        {
            return await _imageUploadService.AddImageUrlProject(file, Id);
        }

        [HttpPost("AddImageUrlSlider")]
        public async Task<ApiResponse> AddImageUrlSlider(IFormFile file, int Id)
        {
            return await _imageUploadService.AddImageUrlSlider(file, Id);
        }

        [HttpPost("AddImageUrlService")]
        public async Task<ApiResponse> AddImageUrlService(IFormFile file, int Id)
        {
            return await _imageUploadService.AddImageUrlService(file, Id);
        }

        [HttpPost("AddFirstImageUrlAboutUs")]
        public async Task<ApiResponse> AddFirstImageUrlAboutUs(IFormFile file, int Id)
        {
            return await _imageUploadService.AddFirstImageUrlAboutUs(file, Id);
        }

        [HttpPost("AddSecondImageUrlAboutUs")]
        public async Task<ApiResponse> AddSecondImageUrlAboutUs(IFormFile file, int Id)
        {
            return await _imageUploadService.AddSecondImageUrlAboutUs(file, Id);
        }

        [HttpPost("AddImageUrlPartner")]
        public async Task<ApiResponse> AddImageUrlPartner(IFormFile file, int Id)
        {
            return await _imageUploadService.AddImageUrlPartner(file, Id);
        }
        [HttpPost("AddImageUrlCompany")]
        public async Task<ApiResponse> AddImageUrlCompany(IFormFile file, int Id)
        {
            return await _imageUploadService.AddImageUrlCompany(file, Id);
        }
        [HttpPost("AddImageUrlMeet")]
        public async Task<ApiResponse> AddImageUrlMeet(IFormFile file, int Id)
        {
            return await _imageUploadService.AddImageUrlMeet(file, Id);
        }
        [HttpPost("AddImageUrlComment")]
        public async Task<ApiResponse> AddImageUrlComment(IFormFile file, int Id)
        {
            return await _imageUploadService.AddImageUrlComment(file, Id);
        }
        [HttpPost("AddImageUrlCustomInfo")]
        public async Task<ApiResponse> AddImageUrlCustomInfo(IFormFile file, int Id)
        {
            return await _imageUploadService.AddImageUrlCustomInfo(file, Id);
        }
        [HttpPost("AddImageUrlProjectGallery")]
        public async Task<ApiResponse> AddImageUrlProjectGallery(IFormFile file, int Id)
        {
            return await _imageUploadService.AddImageUrlProjectGallery(file, Id);
        }
        [HttpPost("AddImageUrlServiceImage")]
        public async Task<ApiResponse> AddImageUrlServiceImage(IFormFile file, int Id)
        {
            return await _imageUploadService.AddImageUrlServiceImage(file, Id);
        }
    }
}
