using CorporateWebSite.API.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateWebSite.API.Entities
{
    public class Comment:BaseEntity
    {
        public string ProfileImgUrl { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeTitle { get; set; }
        public string CommentDescription { get; set; }
        public string BgImgUrl { get; set; }

    }
}
