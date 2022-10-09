using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateWebSite.Shared.Models.RequestModels
{
    public class UpdateProjectDetailRequestModel
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public bool IsActive { get; set; }
    }
}
