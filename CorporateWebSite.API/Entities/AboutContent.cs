using CorporateWebSite.API.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Entities
{
    public class AboutContent:BaseEntity
    {
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }

    }
}
