using AutoWrapper.Wrappers;
using CorporateWebSite.API.Contracts;
using CorporateWebSite.API.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TanvirArjel.EFCore.GenericRepository;

namespace CorporateWebSite.API.Services
{
    public class ImageUploadService : IImageUploadService
    {
        private readonly IRepository _repository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IAboutUsService _aboutUsService;
        private readonly ICustomInfoService _customInfoService;
        private readonly IEmployeesService _employeesService;
        private readonly IPartnerService _partnerService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ImageUploadService(IRepository repository,
            IWebHostEnvironment webHostEnvironment,
            IAboutUsService aboutUsService,
            IHttpContextAccessor httpContextAccessor,
            ICustomInfoService customInfoService,
            IEmployeesService employeesService,
            IPartnerService partnerService)
        {
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
            _aboutUsService = aboutUsService;
            _httpContextAccessor = httpContextAccessor;
            _customInfoService = customInfoService;
            _employeesService = employeesService;
            _partnerService = partnerService;
        }

        
        public async Task<ApiResponse> AddImageUrlAboutUs(IFormFile file, int Id)
        {
            var aboutUs = await _repository.GetByIdAsync<AboutUs>(Id);
            if(aboutUs is not null)
            {
                var fileName = $"{aboutUs.Title}_{DateTime.Now.ToString("yyyyMMddTHHmmss")}.{file.FileName.Split('.').Last()}";
                var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "AboutUsImages", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                aboutUs.ImageUrl= $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value.ToString()}/AboutUsImages/{fileName}";
                await _repository.UpdateAsync(aboutUs);
                return new
                    ("Hakkımızda resmi başarı ile yüklendi.", aboutUs.ImageUrl);
            }
            throw new ApiException("Hakkımızda bilgisi bulunamadı.");
        }

        public async Task<ApiResponse> AddImageUrlCustomInfo(IFormFile file, int Id)
        {
            var customInfo = await _repository.GetByIdAsync<CustomInfo>(Id);
            if (customInfo is not null)
            {
                var fileName = $"{customInfo.Id}_{DateTime.Now.ToString("yyyyMMddTHHmmss")}.{file.FileName.Split('.').Last()}";
                var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "AboutUsImages", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                customInfo.Icon = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value.ToString()}/AboutUsImages/{fileName}";
                await _repository.UpdateAsync(customInfo);
                return new
                    ("Özel bilgilerin resmi başarı ile yüklendi.", customInfo.Icon);
            }
            throw new ApiException("Bilgi bulunamadı.");
        }

        public async Task<ApiResponse> AddImageUrlEmployee(IFormFile file, int Id)
        {
            var employee = await _repository.GetByIdAsync<Employees>(Id);
            if (employee is not null)
            {
                var fileName = $"{employee.Id}_{DateTime.Now.ToString("yyyyMMddTHHmmss")}.{file.FileName.Split('.').Last()}";
                var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "EmployeeImages", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                employee.ProfileImageUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value.ToString()}/EmployeeImages/{fileName}";
                await _repository.UpdateAsync(employee);
                return new
                    ("Personel resmi başarı ile yüklendi.", employee.ProfileImageUrl);
            }
            throw new ApiException("Personel bilgisi bulunamadı.");
        }

        public async Task<ApiResponse> AddImageUrlPartner(IFormFile file, int Id)
        {
            var partner = await _repository.GetByIdAsync<Partner>(Id);
            if (partner is not null)
            {
                var fileName = $"{partner.Name}_{DateTime.Now.ToString("yyyyMMddTHHmmss")}.{file.FileName.Split('.').Last()}";
                var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "PartnerImages", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                partner.Logo = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value.ToString()}/PartnerImages/{fileName}";
                await _repository.UpdateAsync(partner);
                return new
                    ("İş ortağı logosu başarı ile yüklendi.", partner.Logo);
            }
            throw new ApiException("İş ortağı bilgisi bulunamadı.");
        }

        public async Task<ApiResponse> AddImageUrlProject(IFormFile file, int Id)
        {
            var project = await _repository.GetByIdAsync<Project>(Id);
            if (project is not null)
            {
                var fileName = $"{project.Title}_{DateTime.Now.ToString("yyyyMMddTHHmmss")}.{file.FileName.Split('.').Last()}";
                var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "ProjectImages", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                project.ImageUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value.ToString()}/ProjectImages/{fileName}";
                await _repository.UpdateAsync(project);
                return new
                    ("Proje resmi başarı ile yüklendi.", project.ImageUrl);
            }
            throw new ApiException("Proje bilgisi bulunamadı.");
        }

        public async Task<ApiResponse> AddImageUrlService(IFormFile file, int Id)
        {
            var service = await _repository.GetByIdAsync<ServiceSetting>(Id);
            if (service is not null)
            {
                var fileName = $"{service.Title}_{DateTime.Now.ToString("yyyyMMddTHHmmss")}.{file.FileName.Split('.').Last()}";
                var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "ServiceImages", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                service.CoverImageUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value.ToString()}/ServiceImages/{fileName}";
                await _repository.UpdateAsync(service);
                return new
                    ("Hizmet resmi başarı ile yüklendi.", service.CoverImageUrl);
            }
            throw new ApiException("Hizmet bilgisi bulunamadı.");
        }

        public async Task<ApiResponse> AddImageUrlSlider(IFormFile file, int Id)
        {
            var slider = await _repository.GetByIdAsync<Slider>(Id);
            if (slider is not null)
            {
                var fileName = $"{slider.Title}_{DateTime.Now.ToString("yyyyMMddTHHmmss")}.{file.FileName.Split('.').Last()}";
                var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "SliderImages", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                slider.ImageUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value.ToString()}/SliderImages/{fileName}";
                await _repository.UpdateAsync(slider);
                return new
                    ("Slider resmi başarı ile yüklendi.", slider.ImageUrl);
            }
            throw new ApiException("Slider bilgisi bulunamadı.");
        }

        public async Task<ApiResponse> AddFirstImageUrlAboutUs(IFormFile file, int Id)
        {
            var aboutUs = await _repository.GetByIdAsync<AboutContent>(Id);
            if (aboutUs is not null)
            {
                var fileName = $"{aboutUs.Title}_{DateTime.Now.ToString("yyyyMMddTHHmmss")}.{file.FileName.Split('.').Last()}";
                var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "AboutUsImages", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                aboutUs.ImageUrl1 = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value.ToString()}/AboutUsImages/{fileName}";
                await _repository.UpdateAsync(aboutUs);
                return new
                    ("Hakkımızda resmi başarı ile yüklendi.", aboutUs.ImageUrl1);
            }
            throw new ApiException("Hakkımızda bilgisi bulunamadı.");
        }

        public async Task<ApiResponse> AddSecondImageUrlAboutUs(IFormFile file, int Id)
        {
            var aboutUs = await _repository.GetByIdAsync<AboutContent>(Id);
            if (aboutUs is not null)
            {
                var fileName = $"{aboutUs.Title}_{DateTime.Now.ToString("yyyyMMddTHHmmss")}.{file.FileName.Split('.').Last()}";
                var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "AboutUsImages", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                aboutUs.ImageUrl2 = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value.ToString()}/AboutUsImages/{fileName}";
                await _repository.UpdateAsync(aboutUs);
                return new
                    ("Hakkımızda resmi başarı ile yüklendi.", aboutUs.ImageUrl2);
            }
            throw new ApiException("Hakkımızda bilgisi bulunamadı.");
        }

        public async Task<ApiResponse> AddImageUrlCompany(IFormFile file, int Id)
        {
            var company = await _repository.GetByIdAsync<Company>(Id);
            if (company is not null)
            {
               
                var fileName = $"{company.Id}_{DateTime.Now.ToString("yyyyMMddTHHmmss")}.{file.FileName.Split('.').Last()}";
                var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "AboutUsImages", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                company.Logo = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value.ToString()}/AboutUsImages/{fileName}";
                await _repository.UpdateAsync(company);
                return new
                    ("Hakkımızda resmi başarı ile yüklendi.", company.Logo);
            }
            throw new ApiException("Şirket bilgisi bulunamadı.");
        }

        public async Task<ApiResponse> AddImageUrlMeet(IFormFile file, int Id)
        {
            var meet = await _repository.GetByIdAsync<Meet>(Id);
            if (meet is not null)
            {
                var fileName = $"{meet.Id}_{DateTime.Now.ToString("yyyyMMddTHHmmss")}.{file.FileName.Split('.').Last()}";
                var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "MeetImages", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                meet.MeetImageUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value.ToString()}/MeetImages/{fileName}";
                await _repository.UpdateAsync(meet);
                return new
                    ("Hakkımızda resmi başarı ile yüklendi.", meet.MeetImageUrl);
            }
            throw new ApiException("Şirket bilgisi bulunamadı.");
        }

        public async Task<ApiResponse> AddImageUrlComment(IFormFile file, int Id)
        {
            var comment = await _repository.GetByIdAsync<Comment>(Id);
            if (comment is not null)
            {
                var fileName = $"{comment.Id}_{DateTime.Now.ToString("yyyyMMddTHHmmss")}.{file.FileName.Split('.').Last()}";
                var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "EmployeeImages", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                comment.ProfileImgUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value.ToString()}/EmployeeImages/{fileName}";
                await _repository.UpdateAsync(comment);
                return new
                    ("Yorum resmi başarı ile yüklendi.", comment.ProfileImgUrl);
            }
            throw new ApiException("Yorum bilgisi bulunamadı.");
        }

        public async Task<ApiResponse> AddImageUrlProjectGallery(IFormFile file, int Id)
        {
            var projectGallery = await _repository.GetByIdAsync<ProjectGallery>(Id);
            if (projectGallery is not null)
            {
                var fileName = $"$Gallery_{projectGallery.Id}_{DateTime.Now.ToString("yyyyMMddTHHmmss")}.{file.FileName.Split('.').Last()}";
                var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "ProjectImages", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                projectGallery.ImageUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value.ToString()}/ProjectImages/{fileName}";
                await _repository.UpdateAsync(projectGallery);
                return new
                    ("Proje resmi başarı ile yüklendi.", projectGallery.ImageUrl);
            }
            throw new ApiException("Proje bilgisi bulunamadı.");
        }

        public async Task<ApiResponse> AddImageUrlServiceImage(IFormFile file, int Id)
        {
            var service = await _repository.GetByIdAsync<ServiceImage>(Id);
            if (service is not null)
            {
                var fileName = $"{service.Id}_{DateTime.Now.ToString("yyyyMMddTHHmmss")}.{file.FileName.Split('.').Last()}";
                var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "ServiceImages", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                service.ImageUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value.ToString()}/ServiceImages/{fileName}";
                await _repository.UpdateAsync(service);
                return new
                    ("Hizmet içerik resmi başarı ile yüklendi.", service.ImageUrl);
            }
            throw new ApiException("Hizmet içerik bilgisi bulunamadı.");
        }

       
    }
}
