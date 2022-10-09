using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateWebSite.Shared.Models.RequestModels
{
    public class UpdateCommentRequestModel
    {
        public int Id { get; set; }
        public string ProfileImgUrl { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeTitle { get; set; }
        public string CommentDescription { get; set; }
        public string BgImgUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
