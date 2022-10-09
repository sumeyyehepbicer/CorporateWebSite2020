using CorporateWebSite.API.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Entities
{
    public class ProjectGallery:BaseEntity
    {
        public string ImageUrl { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }

    }
}
