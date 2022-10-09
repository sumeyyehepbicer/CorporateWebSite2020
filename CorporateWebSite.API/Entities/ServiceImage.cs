using CorporateWebSite.API.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Entities
{
    public class ServiceImage:BaseEntity
    {
        public string ImageUrl { get; set; }
        public ServiceSetting ServiceSetting { get; set; }
        public int ServiceSettingId { get; set; }
    }
}
