using AutoWrapper.Wrappers;
using CorporateWebSite.API.Contracts;
using CorporateWebSite.API.Controllers.Common;
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
    public class PartnerController : BaseApiController
    {
        private readonly IPartnerService _partnerService;
        public PartnerController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        [HttpGet("GetPartners")]
        public async Task<ApiResponse> GetPartners()
        {
            return await _partnerService.GetPartners();
        }

        [HttpPost("AddPartner")]
        public async Task<ApiResponse> AddPartner(AddPartnerRequestModel req)
        {
            return await _partnerService.AddPartner(req);
        }

        [HttpPost("UpdatePartner")]
        public async Task<ApiResponse> UpdatePartner(UpdatePartnerRequestModel req)
        {
            return await _partnerService.UpdatePartner(req);
        }

        [HttpGet("DeletePartnerById")]
        public async Task<ApiResponse> DeletePartnerById(int id)
        {
            return await _partnerService.DeletePartnerById(id);
        }
    }
}
