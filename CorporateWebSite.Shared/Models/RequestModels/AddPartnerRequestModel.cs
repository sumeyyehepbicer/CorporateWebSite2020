using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateWebSite.Shared.Models.RequestModels
{
    public class AddPartnerRequestModel
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public bool IsActive { get; set; }
    }
}
