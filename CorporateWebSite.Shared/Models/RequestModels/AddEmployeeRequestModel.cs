using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateWebSite.Shared.Models.RequestModels
{
    public class AddEmployeeRequestModel
    {
        public string FullName { get; set; }
        public string Title { get; set; }
        public string EmailAddress { get; set; }
        public string ProfileImageUrl { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string LinkedlnLink { get; set; }
        public bool IsActive { get; set; }
    }
}
