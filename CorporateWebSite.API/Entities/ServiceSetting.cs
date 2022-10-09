using CorporateWebSite.API.Entities.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Entities
{
    public class ServiceSetting:BaseEntity
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string CoverImageUrl { get; set; }
        public string Icon { get; set; }
        public virtual Collection<ServiceImage> ServiceImages { get; set; }

    }
}
