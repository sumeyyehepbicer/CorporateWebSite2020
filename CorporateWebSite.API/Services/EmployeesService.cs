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
    public class EmployeesService:IEmployeesService
    {
        public readonly IRepository _repository;
        public EmployeesService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse> GetEmployees()
        {
            try
            {
                var employees = await _repository.GetListAsync<Employees>();
                return new ApiResponse("Çalışan Bilgileri Başarılı Bir Şekilde Getirildi.", employees, 200);
            }
            catch (Exception)
            {
                throw new ApiException("Çalışan bilgileri getirilirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }
        public async Task<ApiResponse> AddEmployee(AddEmployeeRequestModel req)
        {
            try
            {
                Employees employees = new()
                {
                    EmailAddress=req.EmailAddress,
                    FacebookLink=req.FacebookLink,
                    FullName=req.FullName,
                    IsActive=req.IsActive,
                    LinkedlnLink=req.LinkedlnLink,
                    ProfileImageUrl= string.Empty,
                    Title=req.Title,
                    TwitterLink=req.TwitterLink
                };
                await _repository.InsertAsync<Employees>(employees);
                return new ApiResponse("Çalışan bilginiz başarılı bir şekilde eklenmiştir", employees, 200);

            }
            catch (Exception)
            {
                throw new ApiException("Çalışan bilgileri eklenirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }
        public async Task<ApiResponse> UpdateEmployee(UpdateEmployeeRequestModel req)
        {
            var existEmployee = await _repository.GetByIdAsync<Employees>(req.Id);
            if(existEmployee is not null)
            {
                existEmployee.TwitterLink = req.TwitterLink;
                existEmployee.Title = req.Title;
                existEmployee.ProfileImageUrl = existEmployee.ProfileImageUrl;
                existEmployee.LinkedlnLink = req.LinkedlnLink;
                existEmployee.FullName = req.FullName;
                existEmployee.EmailAddress = req.EmailAddress;
                existEmployee.FacebookLink = req.FacebookLink;
                existEmployee.IsActive = req.IsActive;

                await _repository.UpdateAsync(existEmployee);
                return new ApiResponse("Çalışan bilginiz başarılı bir şekilde güncellenmiştir", existEmployee, 200);
            }
            else
            {
                throw new ApiException("Çalışan bilgileri güncellenirken bir hata oluştu.Lütfen tekrar deneyiniz.", 400);
            }
        }      
        public async Task<ApiResponse> DeleteEmployeeById(int id)
        {
            var isExists = await _repository.GetByIdAsync<Employees>(id);
            if (isExists is null)
            {
                throw new ApiException("Böyle bir çalışan bulunamadı.");
            }
            await _repository.DeleteAsync(isExists);
            return new ApiResponse($"{isExists.FullName} adlı çalışan silinmiştir.");
        }

    }
}
