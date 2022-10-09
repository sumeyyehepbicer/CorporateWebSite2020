using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateWebSite.Shared.Models.RequestModels
{
    public class AddServiceImageRequestModel
    {
        public int ServiceSettingId { get; set; }
        public bool IsActive { get; set; }
    }
}
