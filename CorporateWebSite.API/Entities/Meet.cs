using CorporateWebSite.API.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Entities
{
    public class Meet:BaseEntity
    {
        public string MeetImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
