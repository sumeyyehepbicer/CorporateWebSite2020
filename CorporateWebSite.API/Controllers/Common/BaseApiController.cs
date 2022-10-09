using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Controllers.Common
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        //private int GetUserId()
        //{
        //    return int.Parse(
        //        _httpContextAccessor
        //        .HttpContext?
        //        .User?
        //        .FindFirst(ClaimTypes.NameIdentifier).Value);
        //}
    }
}
